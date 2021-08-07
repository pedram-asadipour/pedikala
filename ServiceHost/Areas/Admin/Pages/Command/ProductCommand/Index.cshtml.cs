using System.Collections.Generic;
using CommandManagement.Application.Contract.ProductCommand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Command.ProductCommand
{
    public class IndexModel : PageModel
    {
        public ProductCommandSearchModel SearchModel { get; set; }
        public List<ProductCommandViewModel> Commands { get; set; }

        private readonly IProductCommandApplication _application;

        public IndexModel(IProductCommandApplication application)
        {
            _application = application;
        }

        public void OnGet(ProductCommandSearchModel searchModel)
        {
            Commands = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(ProductCommandSearchModel searchModel)
        {
            Commands = _application.GetAll(searchModel);
            return Partial("./List", Commands);
        }

        public JsonResult OnGetConfirmed(long id)
        {
            var json = _application.Confirmed(id);
            return new JsonResult(json);
        }

        public JsonResult OnGetCanceled(long id)
        {
            var json = _application.Canceled(id);
            return new JsonResult(json);
        }
    }
}