using _01_PedikalaQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class LastProductsComponent : ViewComponent
    {
        private readonly IProductQuery _query;

        public LastProductsComponent(IProductQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var lastProducts = _query.GetProducts();
            return View(lastProducts);
        }
    }
}