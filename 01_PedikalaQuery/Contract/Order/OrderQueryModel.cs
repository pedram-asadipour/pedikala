using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Order
{
    public class OrderQueryModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string PayAmount { get; set; }
        public bool IsProcessing { get; set; }
        public string IssueTrackingNo { get; set; }
        public long RefId { get; set; }
        public string CreationDate { get; set; }
        public List<OrderItemQueryModel> Items { get; set; }
    }
}