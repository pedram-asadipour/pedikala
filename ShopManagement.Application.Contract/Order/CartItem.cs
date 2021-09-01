namespace ShopManagement.Application.Contract.Order
{
    public class CartItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public bool IsInStock { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountPrice { get; set; }
        public double FinalPrice { get; set; }

        public void CalculateTotalPrice()
        {
            TotalPrice = UnitPrice * Count;
        }

        public void CalculateDiscountPrice()
        {
            DiscountPrice = (TotalPrice * DiscountRate) / 100;
        }

        public void CalculateFinalPrice()
        {
            FinalPrice = TotalPrice - DiscountPrice;
        }
    }

    
}