using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Product
{
    public class ProductWrapQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public bool IsRemoved { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string DiscountPrice { get; set; }
        public string DiscountEndDate { get; set; }
    }
}