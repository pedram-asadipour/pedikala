using System.Collections.Generic;
using _01_PedikalaQuery.Contract.ArticleComment;

namespace _01_PedikalaQuery.Contract.Article
{
    public class ArticleQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public string PublishDate { get; set; }
        public string CanonicalAddress { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ArticleCommentQueryModel> Comments { get; set; }
    }
}