using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Cart;
using DiscountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.Order;

namespace _01_PedikalaQuery.Query
{
    public class CartQuery : ICartQuery
    {
        private readonly IAuthHelper _authHelper;
        private readonly DiscountContext _discountContext;

        public CartQuery(IAuthHelper authHelper, DiscountContext discountContext)
        {
            _authHelper = authHelper;
            _discountContext = discountContext;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();

            var colleagueDiscounts = _discountContext.ColleagueDiscounts
                .Select(x => new {x.ProductId, x.IsRemoved, x.DiscountRate})
                .ToList();

            var customerDiscounts = _discountContext.CustomerDiscounts
                .Select(x => new {x.ProductId, x.IsRemoved, x.DiscountRate, x.StartDate, x.EndDate})
                .ToList();

            var currentAccountRole = _authHelper.GetCurrentAccount().RoleId;

            foreach (var item in cartItems)
            {
                if (currentAccountRole == 1000) // Colleague Role For Test
                {
                    var discount = colleagueDiscounts
                        .FirstOrDefault(x => x.ProductId == item.Id && !x.IsRemoved);
                    if (discount != null)
                        item.DiscountRate = discount.DiscountRate;
                }
                else // Customer Discount
                {
                    var discount = customerDiscounts
                        .FirstOrDefault(x => x.ProductId == item.Id &&
                                             DiscountOperation.DiscountStatus(x.StartDate, x.EndDate, !x.IsRemoved));
                    if (discount != null)
                        item.DiscountRate = discount.DiscountRate;
                }

                item.CalculateTotalPrice();
                item.CalculateDiscountPrice();
                item.CalculateFinalPrice();

                cart.Add(item);
            }

            return cart;
        }
    }
}