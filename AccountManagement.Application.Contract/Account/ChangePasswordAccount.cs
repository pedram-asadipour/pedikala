using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class ChangePasswordAccount
    {
        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("رمز عبور جدید")]
        [MaxLength(18, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [MinLength(8, ErrorMessage = ValidationMessages.MinLengthRequired)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تکرار رمز عبور")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [Compare("NewPassword", ErrorMessage = ValidationMessages.PasswordNotMatch)]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}