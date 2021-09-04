using System.ComponentModel;

namespace ShopManagement.Application.Contract.Order
{
    public class OrderSearchModel
    {
        public long AccountId { get; set; }

        [DisplayName("شماره پیگیری")]
        public string IssueTrackingNo { get; set; }

        [DisplayName("تاریخ فاکتور")]
        public string CreationDate { get; set; }
    }
}