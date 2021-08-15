using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace CommentManagement.Application.Contract.ArticleComment
{
    public class CreateArticleComment
    {
        [Required]
        public long ArticleId { get; set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [DisplayName("ایمیل")]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailRequired)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Email { get; set; }

        [DisplayName("نام سایت")]
        public string WebSite { get; set; }

        [DisplayName("پیغام")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Message { get; set; }

        [Required]
        public long ParentId { get; set; }
    }
}