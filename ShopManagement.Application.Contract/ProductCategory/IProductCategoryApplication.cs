using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        List<ProductCategoryViewModel> GetAll(ProductCategorySearchModel searchModel);
        List<SelectModel> GetAllSelectModel();
        EditProductCategory GetDetail(long id);
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
    }
}