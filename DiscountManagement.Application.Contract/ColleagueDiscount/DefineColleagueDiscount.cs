using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 100, ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("درصد تخفیف")]
        public int DiscountRate { get; set; }
        public List<SelectModel> Products { get; set; }
    }
}