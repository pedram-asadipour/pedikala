using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [Range(1, 100, ErrorMessage = ValidationMessages.PercentRequired)]
        [DisplayName("درصد تخفیف")]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تاریخ شروع تخفیف")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تاریخ پایان تخفیف")]
        public string EndDate { get; set; }

        [DisplayName("دلیل تخفیف")]
        public string Reason { get; set; }
        public List<SelectModel> Products { get; set; }
    }
}