using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class SignInAccount
    {
        public SignInAccount()
        {
            RoleId = AccountRoles.NormalAccount;
        }

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
        [DisplayName("رمز عبور")]
        [MaxLength(18, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [MinLength(8, ErrorMessage = ValidationMessages.MinLengthRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("تکرار رمز عبور")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [Compare("Password", ErrorMessage = ValidationMessages.PasswordNotMatch)]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("شماره موبایل")]
        [MaxLength(20, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [RegularExpression(@"^[0-9]{0,21}", ErrorMessage = ValidationMessages.CharacterRequired + "(فقط عدد 0-9)")]
        public string Mobile { get; set; }

        public long RoleId { get; set; }
    }
}