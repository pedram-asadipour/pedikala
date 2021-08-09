namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public long ArticleCount { get; set; }
        public string CreationDate { get; set; }
    }
}