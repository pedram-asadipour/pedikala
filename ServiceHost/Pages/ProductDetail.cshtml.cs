using _01_PedikalaQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductQuery _query;
        public ProductQueryModel Product { get; set; }

        public ProductDetailModel(IProductQuery query)
        {
            _query = query;
        }

        public IActionResult OnGet(long id)
        {
            if(id == 0)
                return NotFound();

            Product = _query.GetProductBy(id);

            if (Product == null)
                return NotFound();

            return Page();
        }
    }
}
