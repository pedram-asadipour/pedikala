using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contract.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("عنوان مقاله")]
        [MaxLength(500,ErrorMessage = ValidationMessages.LengthRequired)]
        public string Title { get; set; }

        [DisplayName("تصویر مقاله")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("Alt تصویر")]
        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("Title تصویر")]
        [MaxLength(500, ErrorMessage = ValidationMessages.LengthRequired)]
        public string ImageTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("توضیحات کوتاه")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.LengthRequired)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = ValidationMessages.LengthRequired)]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("توضیحات متا")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.LengthRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تاریخ انتشار مقاله")]
        public string PublishDate { get; set; }

        [DisplayName("آدرس مقاله مترادف")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.LengthRequired)]
        [Url(ErrorMessage = ValidationMessages.UrlRequired)]
        public string CanonicalAddress { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("دسته بندی مقاله")]
        public long CategoryId { get; set; }
    }
}