using System.Collections.Generic;
using System.Linq;
using _01_PedikalaQuery.Contract.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryMenuQueryModel> GetCategories()
        {
            return _shopContext.ProductCategories
                .Select(x => new ProductCategoryMenuQueryModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }
    }
}