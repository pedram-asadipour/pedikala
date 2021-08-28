using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName(displayName: "نام گروه محصولات")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName(displayName: "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName(displayName: "کلمات کلیدی")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName(displayName: "توضیحات متا")]
        public string MetaDescription { get; set; }

        [DisplayName(displayName: "تصویر دسته بندی")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName(displayName: "Alt تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName(displayName: "Title تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get; set; }
    }
}