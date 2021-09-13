using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace SiteManagement.Application.Contract.ContactUs
{
    public class CreateContactUs
    {
        [DisplayName("نام")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailRequired)]
        public string Email { get; set; }

        [DisplayName("پیغام")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Message { get; set; }

    }
}