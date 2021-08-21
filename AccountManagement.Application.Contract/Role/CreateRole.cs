using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Role
{
    public class CreateRole
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام نقش")]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLengthRequired)]
        public string Name { get; set; }
    }
}