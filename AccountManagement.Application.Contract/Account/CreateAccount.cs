using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام و نام خانوادگی")]
        [MaxLength(225,ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Fullname { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام کاربری")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Username { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("رمز عبور")]
        [MaxLength(18, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [MinLength(8, ErrorMessage = ValidationMessages.MinLengthRequired)]
        [DataType(DataType.Password)]
        public string Password { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تکرار رمز عبور")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [Compare("Password",ErrorMessage = ValidationMessages.PasswordNotMatch)]
        [DataType(DataType.Password)]
        public string RePassword { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("شماره موبایل")]
        [MaxLength(20, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [RegularExpression(@"^[0-9]{0,21}",ErrorMessage = ValidationMessages.CharacterRequired + "(فقط عدد 0-9)")]
        public string Mobile { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public int RoleId { get;  set; }

        [DisplayName("پروفایل کابربر")]
        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = ValidationMessages.FileSize + ": 5 مگابایت")]
        [FileExtensionLimit(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.FileType + " فایل های مجاز : jpg,jpeg,png")]
        public IFormFile ProfileImage { get;  set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}