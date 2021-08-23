using System.Collections.Generic;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        private readonly IProductCategoryApplication _application;

        public IndexModel(IProductCategoryApplication application)
        {
            _application = application;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _application.GetAll(searchModel);
            return Partial("./List", ProductCategories);
        }

        public PartialViewResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));
            }

            var json = _application.Create(command);
            return new JsonResult(json);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var productCategory = _application.GetDetail(id);
            return Partial("./Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));
            }

            var json = _application.Edit(command);
            return new JsonResult(json);
        }
    }
}