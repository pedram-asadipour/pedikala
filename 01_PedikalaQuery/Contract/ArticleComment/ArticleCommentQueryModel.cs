namespace _01_PedikalaQuery.Contract.ArticleComment
{
    public class ArticleCommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public long ParentId { get; set; }
    }
}