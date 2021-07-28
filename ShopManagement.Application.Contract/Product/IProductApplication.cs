using _01_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        List<ProductViewModel> GetAll(ProductSearchModel searchModel);
        List<SelectModel> GetAllSelectModel();
        EditProduct GetDetail(long id);
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
