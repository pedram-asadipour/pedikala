using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace SiteManagement.Application.Contract.Footer
{
    public class CreateFooterLink
    {
        [DisplayName("نام")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(225,ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Name { get; set; }

        [DisplayName("لینک")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Link { get; set; }
    }
}