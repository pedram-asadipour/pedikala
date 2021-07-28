using System.Collections.Generic;
using _01_Framework.Domain;
using ShopManagement.Application.Contract.ProductPicture;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IGenericRepository<ProductPicture,long>
    {
        List<ProductPictureViewModel> GetAll(ProductPictureSearchModel searchModel);
        EditProductPicture GetDetail(long id);
    }
}