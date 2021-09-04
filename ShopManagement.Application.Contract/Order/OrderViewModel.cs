using System;

namespace ShopManagement.Application.Contract.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string AccountUsername { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountAmount { get; set; }
        public string PayAmount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsProcessing { get; set; }
        public string IssueTrackingNo { get; set; }
        public long RefId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}