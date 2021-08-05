using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Tools;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : GenericRepository<Product, long>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductViewModel> GetAll(ProductSearchModel searchModel)
        {
            var query = _context.Products
                .Include(x => x.ProductCategory)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductCode = x.ProductCode,
                    CreationDate = x.CreationDate.ToPersianDate(),
                    Image = x.Image,
                    CategoryName = x.ProductCategory.Name,
                    CategoryId = x.CategoryId,
                    IsRemoved = x.IsRemoved
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.ProductCode))
                query = query.Where(x => x.ProductCode == searchModel.ProductCode.ToLower());

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            query = query.AsNoTracking();

            return query.ToList();
        }

        public List<SelectModel> GetAllSelectModels()
        {
            return _context.Products
                .Select(x => new SelectModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public EditProduct GetDetail(long id)
        {
            return _context.Products
                .Select(x => new EditProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductCode = x.ProductCode,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    CategoryId = x.CategoryId
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public ProductWithCategoryModel GetCategoryIdBy(long productId)
        {
           return _context.Products
                .Select(x => new ProductWithCategoryModel
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId
                })
                .FirstOrDefault(x => x.Id == productId);
        }
    }
}