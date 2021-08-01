using _01_PedikalaQuery.Contract.Menu;
using _01_PedikalaQuery.Contract.ProductCategory;

namespace _01_PedikalaQuery.Query
{
    public class MenuQuery : IMenuQuery
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public MenuQuery(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public MenuQueryModel GetMenus()
        {
            return new MenuQueryModel
            {
                Categories = _productCategoryQuery.GetCategories()
            };

        }
    }
}