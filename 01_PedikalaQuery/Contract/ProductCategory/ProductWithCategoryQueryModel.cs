using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Product;

namespace _01_PedikalaQuery.Contract.ProductCategory
{
    public class ProductWithCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductWrapQueryModel> Products { get; set; }
    }
}