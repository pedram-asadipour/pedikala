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
            var productQuery = _shopContext.Products
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

            if (productQuery == null) return null;

            var currentInventory = _inventoryContext.Inventories
                .Select(x => new {x.ProductId, x.UnitPrice, x.IsInStock})
                .AsNoTracking()
                .FirstOrDefault(x => x.ProductId == productQuery.Id);
            if (currentInventory == null) return productQuery;

            productQuery.UnitPrice = currentInventory.UnitPrice.ToString("##,###");
            productQuery.IsInStock = currentInventory.IsInStock;

            var currentDiscount = _discountContext.CustomerDiscounts
                .Select(x => new { x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved })
                .AsNoTracking()
                .FirstOrDefault(x => x.ProductId == productQuery.Id);
            if (currentDiscount == null) return productQuery;

            productQuery.HasDiscount = DiscountOperation.DiscountStatus(currentDiscount.StartDate, currentDiscount.EndDate, !currentDiscount.IsRemoved);
            productQuery.DiscountRate = currentDiscount.DiscountRate;
            productQuery.DiscountPrice = CurrencyProcess.GetDiscountPrice(currentDiscount.DiscountRate, currentInventory.UnitPrice).ToString("##,###");
            productQuery.DiscountEndDate = currentDiscount.EndDate.ToString("yyyy/MM/dd");

            return productQuery;
        }

        public List<ProductWrapQueryModel> Search(string search)
        {
            var productsQuery = _shopContext.Products
                .Where(x => x.Name.Contains(search) && !x.IsRemoved)
                .Include(x => x.ProductCategory)
                .Select(x => new ProductWrapQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    IsRemoved = x.IsRemoved,
                    CategoryId = x.ProductCategory.Id,
                    CategoryName = x.ProductCategory.Name
                })
                .AsNoTracking()
                .ToList();

            var inventories = _inventoryContext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice, x.IsInStock })
                .AsNoTracking()
                .AsNoTracking()
                .ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Select(x => new {x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved})
                .AsNoTracking()
                .ToList();

            foreach (var product in productsQuery)
            {
                var currentInventory = _inventoryContext.Inventories
                    .Select(x => new { x.ProductId, x.UnitPrice, x.IsInStock })
                    .FirstOrDefault(x => x.ProductId == product.Id);
                if (currentInventory == null) continue;

                product.UnitPrice = currentInventory.UnitPrice.ToString("##,###");
                product.IsInStock = currentInventory.IsInStock;


                var currentDiscount = _discountContext.CustomerDiscounts
                    .Select(x => new { x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved })
                    .FirstOrDefault(x => x.ProductId == product.Id);
                if (currentDiscount == null) continue;

                product.HasDiscount = DiscountOperation.DiscountStatus(currentDiscount.StartDate, currentDiscount.EndDate, !currentDiscount.IsRemoved);
                product.DiscountRate = currentDiscount.DiscountRate;
                product.DiscountPrice = CurrencyProcess.GetDiscountPrice(currentDiscount.DiscountRate, currentInventory.UnitPrice).ToString("##,###");
                product.DiscountEndDate = currentDiscount.EndDate.ToString("yyyy/MM/dd");
            }

            return productsQuery;
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
                })
                .ToList();
        }
    }
}