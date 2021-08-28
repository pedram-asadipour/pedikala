using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory, long>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductCategoryViewModel> GetAll(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    CreationDate = x.CreationDate.ToPersianDate()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            query = query.AsNoTracking();

            query = query.OrderByDescending(x => x.Id);

            return query.ToList();
        }

        public List<SelectModel> GetAllSelectModel()
        {
            return _context.ProductCategories
                .Select(x => new SelectModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .AsNoTracking()
                .ToList();
        }

        public EditProductCategory GetDetail(long id)
        {
            return _context.ProductCategories
                .Select(x => new EditProductCategory()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    // Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public string GetName(long id)
        {
            return _context.ProductCategories
                .Select(x => new {x.Id, x.Name})
                .FirstOrDefault(x => x.Id == id)?.Name;

        }
    }
}