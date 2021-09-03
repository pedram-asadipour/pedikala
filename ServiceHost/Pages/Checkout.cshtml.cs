using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Application.ZarinPal;
using _01_PedikalaQuery.Contract.Cart;
using _01_PedikalaQuery.Contract.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly IInventoryQuery _query;
        private readonly ICartQuery _cartQuery;
        private readonly ICartService _cartService;
        private readonly IOrderApplication _orderApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IZarinPalService _zarinPal;

        public List<CartItem> CartItems { get; set; }
        public Cart Cart { get; set; }
        public string Prefix { get; set; }
        public const string CookieName = "cart-items";

        public CheckoutModel(IInventoryQuery query, ICartQuery cartQuery, ICartService cartService,
            IOrderApplication orderApplication, IAuthHelper authHelper, IConfiguration configuration,
            IZarinPalService zarinPal)
        {
            _query = query;
            _cartQuery = cartQuery;
            _cartService = cartService;
            _orderApplication = orderApplication;
            _authHelper = authHelper;
            _zarinPal = zarinPal;

            Prefix = configuration.GetSection("payment")["method"];
        }

        public IActionResult OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var cookie = Request.Cookies[CookieName];
            CartItems = serializer.Deserialize<List<CartItem>>(cookie);

            if (CartItems == null)
                return Redirect("./Cart");

            CartItems = _query.CheckInventory(CartItems);

            if (CartItems == null || CartItems.Any(x => !x.IsInStock))
                return Redirect("./Cart");

            foreach (var item in CartItems)
                item.CalculateTotalPrice();

            Cart = _cartQuery.ComputeCart(CartItems);

            _cartService.Set(Cart);

            return Page();
        }

        public IActionResult OnGetGoToPay()
        {
            Cart = _cartService.Get();

            Cart = _cartQuery.ComputeCart(Cart.CartItems);

            if (Cart.CartItems.Any(x => !x.IsInStock))
                return Redirect("./Cart");

            var currentAccount = _authHelper.GetCurrentAccount();

            var orderId = _orderApplication.PlaceOrder(Cart);


            var result = _zarinPal.PaymentRequest(Cart.Pay,
                currentAccount.Mobile,
                currentAccount.Username,
                $"خرید مشتری : {currentAccount.Fullname}",
                orderId);

            if (result.Status == 100)
                return Redirect($"https://{Prefix}.zarinpal.com/pg/StartPay/{result.Authority}");

            _orderApplication.DeleteOrderBy(orderId);
            return Redirect("./Cart");
        }

        public IActionResult OnGetCallBack([FromQuery] long orderId, [FromQuery] string authority,
            [FromQuery] string status)
        {
            Cart = _cartService.Get();

            var result = _zarinPal.VerificationRequest(authority, Cart.Pay);

            if (result.Status == 100)
            {
                var issueTrackingNo = _orderApplication.PaySucceeded(orderId, result.RefID);

                Response.Cookies.Delete(CookieName);

                return Redirect($"./PayResult?status={true}&issueTrackingNo={issueTrackingNo}");
            }

            _orderApplication.DeleteOrderBy(orderId);
            return Redirect($"./PayResult?status={false}");
        }
    }
}