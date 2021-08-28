using System.Collections.Generic;
using _01_Framework.Application;
using _01_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory, long>
    {
        List<ProductCategoryViewModel> GetAll(ProductCategorySearchModel searchModel);
        List<SelectModel> GetAllSelectModel();
        EditProductCategory GetDetail(long id);
        string GetName(long id);
    }
}