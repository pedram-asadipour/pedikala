using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Product;
using _01_PedikalaQuery.Contract.ProductPicture;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;

        public ProductQuery(ShopContext shopContext, DiscountContext discountContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }


        public ProductQueryModel GetProductBy(long productId)
        {
            var product = _shopContext.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductPictures)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductCode = x.ProductCode,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    IsRemoved = x.IsRemoved,
                    CategoryId = x.CategoryId,
                    CategoryName = x.ProductCategory.Name,
                    Pictures = PicturesMapping(x.ProductPictures)
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == productId && !x.IsRemoved);

            if (product == null) return null;

            var inventoryQuery = _inventoryContext.Inventories
                .Select(x => new {x.ProductId, x.UnitPrice, x.IsInStock})
                .FirstOrDefault(x => x.ProductId == product.Id);

            var discountQuery = _discountContext.CustomerDiscounts
                .Select(x => new {x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved})
                .FirstOrDefault(x => x.ProductId == product.Id);

            if (inventoryQuery == null) return product;

            if (!inventoryQuery.IsInStock) return product;

            product.UnitPrice = inventoryQuery.UnitPrice.ToString("##,###");
            product.IsInStock = true;

            if (discountQuery == null) return product;

            product.HasDiscount = DiscountOperation.DiscountStatus(discountQuery.StartDate,
                discountQuery.EndDate, !discountQuery.IsRemoved);
            product.DiscountRate = discountQuery.DiscountRate;
            product.DiscountPrice = CurrencyProcess
                .GetDiscountPrice(discountQuery.DiscountRate, inventoryQuery.UnitPrice)
                .ToString("##,###");
            product.DiscountEndDate = discountQuery.EndDate.ToString("yyyy/MM/dd");


            return product;
        }

        private static List<ProductPictureQueryModel> PicturesMapping(IEnumerable<ProductPicture> productPictures)
        {
            return productPictures
                .Where(x => !x.IsRemoved)
                .Select(picture => new ProductPictureQueryModel
                {
                    Id = picture.Id,
                    Image = picture.Image,
                    ImageAlt = picture.ImageAlt,
                    ImageTitle = picture.ImageTitle
                }).ToList();
        }
    }
}