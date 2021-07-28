using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public interface IProductPictureApplication
    {
        List<ProductPictureViewModel> GetAll(ProductPictureSearchModel searchModel);
        EditProductPicture GetDetail(long id);
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult Removed(long id);
        OperationResult Restore(long id);
    }
}