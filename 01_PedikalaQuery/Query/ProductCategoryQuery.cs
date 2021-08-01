using System;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Product;
using _01_PedikalaQuery.Contract.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
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
                .ToList();
        }

        public ProductCategoryQueryModel GetCategoryBy(long id)
        {
            var products = _shopContext.Products
                .Where(x => x.CategoryId == id && !x.IsRemoved)
                .Select(x => new ProductWrapQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    IsRemoved = x.IsRemoved,
                })
                .AsNoTracking()
                .ToList();

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
                    Products = products
                })
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .First(x => x.Id == id);


            foreach (var product in categoryQuery.Products)
            {
                var inventoryQuery = _inventoryContext.Inventories
                    .Select(x => new {x.ProductId, x.UnitPrice, x.IsInStock})
                    .FirstOrDefault(x => x.ProductId == product.Id);

                var discountQuery = _discountContext.CustomerDiscounts
                    .Select(x => new {x.ProductId, x.DiscountRate, x.StartDate, x.EndDate, x.IsRemoved})
                    .FirstOrDefault(x => x.ProductId == product.Id);

                if (inventoryQuery == null) continue;

                product.UnitPrice = inventoryQuery.UnitPrice.ToString("##,###");
                product.IsInStock = inventoryQuery.IsInStock;

                if (discountQuery == null) continue;

                if (!DiscountOperation.DiscountStatus(discountQuery.StartDate, discountQuery.EndDate, !discountQuery.IsRemoved)) continue;

                product.HasDiscount = true;
                product.DiscountRate = discountQuery.DiscountRate;
                product.DiscountPrice = CurrencyProcess
                    .GetDiscountPrice(discountQuery.DiscountRate, inventoryQuery.UnitPrice)
                    .ToString("##,###");
                product.DiscountEndDate = discountQuery.EndDate.ToString("yyyy/MM/dd");
            }

            return categoryQuery;
        }
    }
}