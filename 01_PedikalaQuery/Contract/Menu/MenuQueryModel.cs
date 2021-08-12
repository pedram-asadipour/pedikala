using System.Collections.Generic;
using _01_PedikalaQuery.Contract.ArticleCategory;
using _01_PedikalaQuery.Contract.ProductCategory;

namespace _01_PedikalaQuery.Contract.Menu
{
    public class MenuQueryModel
    {
        public List<ProductCategoryMenuQueryModel> ProductCategories { get; set; }
        public List<ArticleCategoryMenuQueryModel> ArticleCategories { get; set; }
    }
}
