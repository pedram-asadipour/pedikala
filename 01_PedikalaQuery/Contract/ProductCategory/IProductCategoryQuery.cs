using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryMenuQueryModel> GetCategories();
        ProductCategoryQueryModel GetCategoryBy(long id);
        List<ProductWithCategoryQueryModel> GetProductsWithCategories();
    }
}