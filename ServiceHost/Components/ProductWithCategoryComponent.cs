using _01_PedikalaQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class ProductWithCategoryComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _query;

        public ProductWithCategoryComponent(IProductCategoryQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var productsWithCategories = _query.GetProductsWithCategories();
            return View(productsWithCategories);
        }
    }
}