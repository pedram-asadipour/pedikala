using System;
using System.ComponentModel;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {
        public long ProductId { get; set; }

        [DisplayName("تاریخ شروع")]
        public string StartDate { get; set; }

        [DisplayName("تاریخ پایان")]
        public string EndDate { get; set; }
    }
}