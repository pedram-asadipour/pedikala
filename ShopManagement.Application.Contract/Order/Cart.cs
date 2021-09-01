using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Order
{
    public class Cart
    {
        public double TotalAmounts { get; set; }
        public double TotalDiscounts { get; set; }
        public double Pay { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public void Add(CartItem item)
        {
            CartItems.Add(item);

            TotalAmounts += item.TotalPrice;
            TotalDiscounts += item.DiscountPrice;
            Pay += item.FinalPrice;
        }
    }
}