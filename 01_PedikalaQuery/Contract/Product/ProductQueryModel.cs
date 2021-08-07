using System.Collections.Generic;
using _01_PedikalaQuery.Contract.ProductComment;
using _01_PedikalaQuery.Contract.ProductPicture;

namespace _01_PedikalaQuery.Contract.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public string ProductCode { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public bool IsRemoved { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string DiscountPrice { get; set; }
        public string DiscountEndDate { get; set; }
        public List<ProductCommandQueryModel> Comments { get; set; }
        public List<ProductPictureQueryModel> Pictures { get; set; }
    }
}