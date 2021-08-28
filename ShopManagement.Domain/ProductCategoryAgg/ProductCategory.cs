using System.Collections.Generic;
using _01_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public List<Product> Products { get; private set; }

        protected ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string description, string image, string imageAlt, string imageTitle,
            string keyword, string metaDescription)
        {
            Name = name;
            Description = description;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
        }

        public void Edit(string name, string description, string image, string imageAlt, string imageTitle,
            string keyword, string metaDescription)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(image))
                Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keyword = keyword;
            MetaDescription = metaDescription;
        }
    }
}