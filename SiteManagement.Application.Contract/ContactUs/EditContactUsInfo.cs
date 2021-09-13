using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace SiteManagement.Application.Contract.ContactUs
{
    public class EditContactUsInfo
    {
        public long Id { get; set; }
        
        [DisplayName("توضیحات")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }

        [DisplayName("embed آدرس در گوگل مپ")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Location { get; set; }
    }
}