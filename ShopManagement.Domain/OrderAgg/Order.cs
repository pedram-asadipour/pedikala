using System.Collections.Generic;
using _01_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBase
    {
        public long AccountId { get; private set; }
        public double TotalAmount { get; private set; }
        public double PayAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsCancel { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }
        public List<OrderItem> Items { get; private set; }

        protected Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(long accountId,double totalAmount, double payAmount, double discountAmount)
        {
            AccountId = accountId;
            TotalAmount = totalAmount;
            PayAmount = payAmount;
            DiscountAmount = discountAmount;
            IsPaid = false;
            IsCancel = false;
            Items = new List<OrderItem>();
        }

        public void PaySucceeded(long refId,string issueTrackingNo)
        {
            IsPaid = true;
            RefId = refId;
            IssueTrackingNo = issueTrackingNo;
        }

        public void Canceled()
        {
            IsCancel = true;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}