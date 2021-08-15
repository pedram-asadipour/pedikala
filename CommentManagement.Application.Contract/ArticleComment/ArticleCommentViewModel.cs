namespace CommentManagement.Application.Contract.ArticleComment
{
    public class ArticleCommentViewModel
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
    }
}