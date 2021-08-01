using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Product;

namespace _01_PedikalaQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryMenuQueryModel> GetCategories();
        ProductCategoryQueryModel GetCategoryBy(long id);
    }
}