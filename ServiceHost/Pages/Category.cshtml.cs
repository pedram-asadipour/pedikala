using _01_PedikalaQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProductCategoryQuery _query;
        public ProductCategoryQueryModel Category { get; set; }

        public CategoryModel(IProductCategoryQuery query)
        {
            _query = query;
        }

        public IActionResult OnGet(long id,string slug)
        {
            if (id == 0)
                return NotFound();

            Category = _query.GetCategoryBy(id);

            if (Category == null)
                return NotFound();

            return Page();
        }
    }
}
