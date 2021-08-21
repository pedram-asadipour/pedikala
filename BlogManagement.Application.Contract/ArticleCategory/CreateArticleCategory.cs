using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام")]
        [MaxLength(225,ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("توضیحات")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Description { get; set; }

        [DisplayName("تصویر دسته بندی")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("Altتصویر")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("Titleتصویر")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string ImageTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("کلمات کلیدی")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("توضیحات متا")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string MetaDescription { get; set; }
    }
}