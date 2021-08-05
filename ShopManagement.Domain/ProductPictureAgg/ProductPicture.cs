using _01_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public long ProductId { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public bool IsRemoved { get; private set; }
        public Product Product { get; private set; }

        protected ProductPicture()
        {
        }

        public ProductPicture(long productId, string image, string imageAlt, string imageTitle)
        {
            ProductId = productId;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            IsRemoved = false;
        }

        public void Edit(long productId, string image, string imageAlt, string imageTitle)
        {
            ProductId = productId;
            if (!string.IsNullOrWhiteSpace(image))
                Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
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