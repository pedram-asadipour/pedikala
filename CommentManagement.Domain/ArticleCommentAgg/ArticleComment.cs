using System.Collections.Generic;
using _01_Framework.Domain;

namespace CommentManagement.Domain.ArticleCommentAgg
{
    public class ArticleComment : EntityBase
    {
        public long ArticleId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string WebSite { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long ParentId { get; private set; }
        public ArticleComment Parent { get; private set; }

        public ArticleComment()
        {
        }

        public ArticleComment(long articleId, string name, string email, string message, string webSite, long parentId)
        {
            ArticleId = articleId;
            Name = name;
            Email = email;
            Message = message;
            ParentId = parentId;
            WebSite = webSite;
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