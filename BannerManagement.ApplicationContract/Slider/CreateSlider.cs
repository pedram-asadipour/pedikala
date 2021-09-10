using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BannerManagement.ApplicationContract.Slider
{
    public class CreateSlider
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("عتوان اول")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string TitleOne { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("عتوان دوم")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string TitleTwo { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("توضیحات")]
        [MaxLength(1200, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Description { get; set; }

        [DisplayName("تصویر اسلایدر")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 5 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("Alt تصویر")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("Title تصویر")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string ImageTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("لینک اسلایدر")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Link { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("پایان نمایش")]
        public string LifeTime { get; set; }
    }
}