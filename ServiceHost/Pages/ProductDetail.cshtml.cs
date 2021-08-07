using _01_PedikalaQuery.Contract.Product;
using CommandManagement.Application.Contract.ProductCommand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductQuery _query;
        private readonly IProductCommandApplication _application;
        public ProductQueryModel Product { get; set; }
        public CreateProductCommand Command { get; set; }
        [ViewData] public string CommandStatusMessage { get; set; }
        [ViewData] public bool IsCommandSend { get; set; }

        public ProductDetailModel(IProductQuery query, IProductCommandApplication application)
        {
            _query = query;
            _application = application;
        }

        public IActionResult OnGet(long id)
        {
            if (id == 0)
                return NotFound();

            Product = GetProduct(id);

            if (Product == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost(CreateProductCommand command)
        {

            if (!ModelState.IsValid)
            {
                CommandStatusMessage = "همه فیلد ها برای نظر درباره محصول اجباری می باشد";

                IsCommandSend = false;

                Product = GetProduct(command.ProductId);

                if (Product == null)
                    return NotFound();

                return Page();
            }

            var json = _application.Create(command);

            CommandStatusMessage = json.IsSucceeded switch
            {
                true => "نظر شما با موفقیت ثبت شد و در صف برسی قرار گرفت",
                false => "نظر شما ثبت نشد"
            };

            IsCommandSend = json.IsSucceeded switch
            {
                true => true,
                false => false
            };

            Product = GetProduct(command.ProductId);

            if (Product == null)
                return NotFound();

            return Page();
        }

        public ProductQueryModel GetProduct(long id)
        {
            return _query.GetProductBy(id);
        }
    }
}