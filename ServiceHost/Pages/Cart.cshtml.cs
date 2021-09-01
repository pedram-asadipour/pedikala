using System;
using System.Collections.Generic;
using System.Linq;
using _01_PedikalaQuery.Contract.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        private readonly IInventoryQuery _query;

        public CartModel(IInventoryQuery query)
        {
            _query = query;
        }

        public List<CartItem> CartItems { get; set; }
        public const string CookieName = "cart-items";

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var cookie = Request.Cookies[CookieName];
            CartItems = serializer.Deserialize<List<CartItem>>(cookie);

            if (CartItems == null)
                return;

            CartItems = _query.CheckInventory(CartItems);

            foreach (var item in CartItems)
                item.CalculateTotalPrice();
        }

        public IActionResult OnGetRemoveInCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var cookie = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            CartItems = serializer.Deserialize<List<CartItem>>(cookie);

            if (CartItems == null)
                return Redirect("./Cart");

            var cartItem = CartItems.Find(x => x.Id == id);
            CartItems.Remove(cartItem);
            
            var options = new CookieOptions
            {
                Path = "/",
                IsEssential = true,
                Expires = DateTime.Now.AddDays(1)
            };
            
            Response.Cookies.Append(CookieName, serializer.Serialize(CartItems), options);
            
            return Redirect("./Cart");
        }

        public IActionResult OnGetCheckCart()
        {
            var serializer = new JavaScriptSerializer();
            var cookie = Request.Cookies[CookieName];
            CartItems = serializer.Deserialize<List<CartItem>>(cookie);

            if (CartItems == null)
                return Redirect("./Cart");

            CartItems = _query.CheckInventory(CartItems);

            foreach (var item in CartItems)
                item.CalculateTotalPrice();

            if (CartItems.Any(x => !x.IsInStock))
                return Page();

            return Redirect("./Checkout");
        }
    }
}
