using _01_PedikalaQuery.Contract.ArticleCategory;
using _01_PedikalaQuery.Contract.Menu;
using _01_PedikalaQuery.Contract.ProductCategory;

namespace _01_PedikalaQuery.Query
{
    public class MenuQuery : IMenuQuery
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuQuery(IProductCategoryQuery productCategoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public MenuQueryModel GetMenus()
        {
            return new MenuQueryModel
            {
                ProductCategories = _productCategoryQuery.GetCategories(),
                ArticleCategories = _articleCategoryQuery.GetCategories()
            };

        }
    }
}