namespace ShopManagement.Domain.OrderAgg
{
    public class OrderItem
    {
        public long Id { get; private set; }
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public int Count { get; private set; }
        public double TotalPrice { get; private set; }
        public int DiscountRate { get; private set; }
        public long OrderId { get; private set; }
        public Order Order { get; private set; }

        public OrderItem(long productId,double unitPrice, int count, double totalPrice, int discountRate)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Count = count;
            TotalPrice = totalPrice;
            DiscountRate = discountRate;
        }
    }
}