using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Product;
using _01_PedikalaQuery.Contract.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;

        public ProductCategoryQuery(ShopContext shopContext, DiscountContext discountContext,
            InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }

        public List<ProductCategoryMenuQueryModel> GetCategories()
        {
            return _shopContext.ProductCategories
                .Select(x => new ProductCategoryMenuQueryModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .AsNoTracking()
                .ToList();
        }

        public ProductCategoryQueryModel GetCategoryBy(long id)
        {
            var categoryQuery = _shopContext.ProductCategories
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    Products = ProductsMapping(x.Products)
                })
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (categoryQuery == null) return null;

            var inventoryQuery = _inventoryContext.Inventories
                .Select(x => new {x.ProductId, x.UnitPrice, x.IsInStock})
                .AsNoTracking()
                .ToList();

            var discountQuery = _discountContext.CustomerDiscounts
                .Select(x => new {x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved})
                .AsNoTracking()
                .ToList();


            foreach (var product in categoryQuery.Products)
            {

                var currentInventory = inventoryQuery.FirstOrDefault(x => x.ProductId == product.Id);
                if (currentInventory == null) continue;

                product.UnitPrice = currentInventory.UnitPrice.ToString("##,###");
                product.IsInStock = currentInventory.IsInStock;

                var currentDiscount = discountQuery.FirstOrDefault(x => x.ProductId == product.Id && !x.IsRemoved);
                if (currentDiscount == null) continue;

                product.HasDiscount = DiscountOperation.DiscountStatus(currentDiscount.StartDate, currentDiscount.EndDate, !currentDiscount.IsRemoved);
                product.DiscountRate = currentDiscount.DiscountRate;
                product.DiscountEndDate = currentDiscount.EndDate.ToString("yyyy/MM/dd");
                product.DiscountPrice = CurrencyProcess.GetDiscountPrice(currentDiscount.DiscountRate,currentInventory.UnitPrice).ToString("##,###");
            }

            return categoryQuery;
        }

        public List<ProductWithCategoryQueryModel> GetProductsWithCategories()
        {
            var categoryQuery = _shopContext.ProductCategories
               .Select(x => new ProductWithCategoryQueryModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Products = ProductsMapping(x.Products).Take(6).ToList()
               })
               .OrderByDescending(x => x.Id)
               .AsNoTracking()
               .ToList();

            var inventoryQuery = _inventoryContext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice, x.IsInStock })
                .AsNoTracking()
                .ToList();

            var discountQuery = _discountContext.CustomerDiscounts
                .Select(x => new { x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved })
                .AsNoTracking()
                .ToList();


            foreach (var category in categoryQuery)
            {
                foreach (var product in category.Products)
                {

                    var currentInventory = inventoryQuery.FirstOrDefault(x => x.ProductId == product.Id);
                    if (currentInventory == null) continue;

                    product.UnitPrice = currentInventory.UnitPrice.ToString("##,###");
                    product.IsInStock = currentInventory.IsInStock;

                    var currentDiscount = discountQuery.FirstOrDefault(x => x.ProductId == product.Id && !x.IsRemoved);
                    if (currentDiscount == null) continue;

                    product.HasDiscount = DiscountOperation.DiscountStatus(currentDiscount.StartDate, currentDiscount.EndDate, !currentDiscount.IsRemoved);
                    product.DiscountRate = currentDiscount.DiscountRate;
                    product.DiscountEndDate = currentDiscount.EndDate.ToString("yyyy/MM/dd");
                    product.DiscountPrice = CurrencyProcess.GetDiscountPrice(currentDiscount.DiscountRate, currentInventory.UnitPrice).ToString("##,###");
                }
            }

            return categoryQuery;
        }

        private static List<ProductWrapQueryModel> ProductsMapping(IEnumerable<Product> products)
        {
            return products
                .Where(x => !x.IsRemoved)
                .Select(x => new ProductWrapQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    IsRemoved = x.IsRemoved,
                })
                .OrderByDescending(x => x.Id)
                .ToList();
        }
    }
}