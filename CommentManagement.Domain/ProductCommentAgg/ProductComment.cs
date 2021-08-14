using _01_Framework.Domain;

namespace CommentManagement.Domain.ProductCommentAgg
{
    public class ProductComment : EntityBase
    {
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }

        protected ProductComment()
        {
        }

        public ProductComment(long productId, string name, string email, string message)
        {
            ProductId = productId;
            Name = name;
            Email = email;
            Message = message;
            IsConfirmed = false;
            IsCanceled = false;
        }

        public void IsConfirm()
        {
            IsConfirmed = true;
        }

        public void IsCancel()
        {
            IsCanceled = true;
        }
    }
}