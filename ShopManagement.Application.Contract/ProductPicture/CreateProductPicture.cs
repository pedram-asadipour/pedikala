using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1, int.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تصویر محصول")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("Alt تصویر")]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("Title تصویر")]
        public string ImageTitle { get; set; }

        public List<SelectModel> Products { get; set; }
    }
}