using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class LogInAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام کاربری")]
        [MaxLength(225, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}