using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Article;

namespace _01_PedikalaQuery.Contract.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public List<ArticleWrapQueryModel> Articles { get; set; }
    }
}