using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class EditProductCategory : CreateProductCategory
    {
        public long Id { get; set; }

        [DisplayName(displayName: "تصویر دسته بندی")]
        [MaxFileSize(3*1024*1024,ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] {".jpg",".jpeg",".png"},ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [MaxLength(255, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "Alt تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        [DisplayName(displayName: "Title تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get; set; }
    }
}