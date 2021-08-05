﻿using _01_Framework.Domain;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IGenericRepository<Product,long>
    {
        List<ProductViewModel> GetAll(ProductSearchModel searchModel);
        List<SelectModel> GetAllSelectModels();
        EditProduct GetDetail(long id);
        ProductWithCategoryModel GetCategoryIdBy(long productId);
    }
}
