using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : GenericRepository<ProductPicture,long> , IProductPictureRepository
    {
        private readonly ShopContext _context;
        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductPictureViewModel> GetAll(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures
                .Include(x => x.Product)
                .Select(x => new ProductPictureViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Image = x.Image,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToPersianDate()
                });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            query = query.AsNoTracking();

            query = query.OrderByDescending(x => x.Id);

            return query.ToList();
        }

        public EditProductPicture GetDetail(long id)
        {
            return _context.ProductPictures
                .Select(x => new EditProductPicture
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}