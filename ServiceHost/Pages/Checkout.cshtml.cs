using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_PedikalaQuery.Contract.Cart;
using _01_PedikalaQuery.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IInventoryQuery _query;
        private readonly ICartQuery _cartQuery;

        public List<CartItem> CartItems { get; set; }
        public Cart Cart { get; set; }
        public const string CookieName = "cart-items";

        public CheckoutModel(IAuthHelper authHelper, IInventoryQuery query, ICartQuery cartQuery)
        {
            _authHelper = authHelper;
            _query = query;
            _cartQuery = cartQuery;
        }

        public IActionResult OnGet()
        {
            if(!_authHelper.IsAuthenticated())
                return Redirect("./Account");

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

            return Page();
        }
    }
}
