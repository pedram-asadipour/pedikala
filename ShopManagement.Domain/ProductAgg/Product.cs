using System.Collections.Generic;
using _01_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public bool IsRemoved { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }

        protected Product()
        {
            ProductPictures = new List<ProductPicture>();
        }

        public Product(string name, string productCode, string shortDescription, 
            string description, string image, string imageAlt, string imageTitle,
            string keyword, string metaDescription, long categoryId)
        {
            Name = name;
            ProductCode = productCode;
            ShortDescription = shortDescription;
            Description = description;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            IsRemoved = false;
            CategoryId = categoryId;
        }

        public void Edit(string name, string productCode, string shortDescription,
            string description, string image, string imageAlt, string imageTitle,
            string keyword, string metaDescription, long categoryId)
        {
            Name = name;
            ProductCode = productCode;
            ShortDescription = shortDescription;
            Description = description;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public void Removed()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
