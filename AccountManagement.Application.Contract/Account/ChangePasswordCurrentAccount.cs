using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class ChangePasswordCurrentAccount : ChangePasswordAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("رمز عبور فعلی")]
        [MaxLength(18, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        [MinLength(8, ErrorMessage = ValidationMessages.MinLengthRequired)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}