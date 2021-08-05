using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.Product
{
    public class EditProduct : CreateProduct
    {
        public long Id { get; set; }

        [DisplayName("تصویر محصول")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [MaxLength(225, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("Alt تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName("Title تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get; set; }
    }
}
