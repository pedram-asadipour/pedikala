using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace CommentManagement.Application.Contract.ProductComment
{
    public class CreateProductComment
    {
        [Required]
        public long ProductId { get; set; }
        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DisplayName("پیغام")]
        public string Message { get; set; }
    }
}