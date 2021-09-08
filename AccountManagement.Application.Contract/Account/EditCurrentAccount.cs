using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class EditCurrentAccount
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام و نام خانوادگی")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام کاربری")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("شماره موبایل")]
        [MaxLength(20, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [RegularExpression(@"^[0-9]{0,21}", ErrorMessage = ValidationMessages.CharacterRequired + "(فقط عدد 0-9)")]
        public string Mobile { get; set; }

        [DisplayName("پروفایل کاربر")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 5 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile ProfileImage { get; set; }
    }
}