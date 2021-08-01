using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Product;

namespace _01_PedikalaQuery.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductWrapQueryModel> Products { get; set; }
    }
}