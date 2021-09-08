using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Order
{
    public class OrderItemQueryModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public int Count { get; set; }
        public int DiscountRate { get; set; }
        public string Pay { get; set; }
    }

    public interface IOrderQuery
    {
        List<OrderQueryModel> GetOrderBy(long accountId);
    }
}