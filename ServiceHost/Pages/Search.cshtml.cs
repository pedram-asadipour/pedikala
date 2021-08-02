using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProductQuery _query;
        public List<ProductWrapQueryModel> Products { get; set; }
        [TempData] public string Search { get; set; }

        public SearchModel(IProductQuery query)
        {
            _query = query;
        }

        public IActionResult OnGet(string search)
        {
            Products = _query.Search(search);
            Search = search;
            return Page();
        }
    }
}
