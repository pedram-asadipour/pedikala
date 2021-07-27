using System;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public string Image { get; set; }
    }
}