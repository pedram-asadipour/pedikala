using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(225,ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("نام محصول")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(15, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("کد محصول")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("توضیحات کوتاه")]
        public string ShortDescription { get; set; }

        [MaxLength(5000, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("کلمات کلیدی")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("توضیحات متا")]
        public string MetaDescription { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }


        [DisplayName("تصویر محصول")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 3 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("Alt تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [DisplayName("Title تصویر")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get; set; }

        public List<SelectModel> Categories { get; set; }
    }
}
