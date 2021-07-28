using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel { get; set; }
        public SelectList Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }

        private readonly IProductApplication _application;
        private readonly IProductCategoryApplication _categoryApplication;

        public IndexModel(IProductApplication application, IProductCategoryApplication categoryApplication)
        {
            _application = application;
            _categoryApplication = categoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Categories = new SelectList(_categoryApplication.GetAllSelectModel(), "Id", "Name");
            Products = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(ProductSearchModel searchModel)
        {
            Products = _application.GetAll(searchModel);
            return Partial("./List", Products);
        }

        public PartialViewResult OnGetCreate()
        {
            var createProduct = new CreateProduct()
            {
                Categories = _categoryApplication.GetAllSelectModel()
            };

            return Partial("./Create", createProduct);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var json = _application.Create(command);
            return new JsonResult(json);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var productCategory = _application.GetDetail(id);

            productCategory.Categories = _categoryApplication.GetAllSelectModel();

            return Partial("./Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        public JsonResult OnGetRemove(long id)
        {
            var json = _application.Remove(id);
            return new JsonResult(json);
        }

        public JsonResult OnGetRestore(long id)
        {
            var json = _application.Restore(id);
            return new JsonResult(json);
        }
    }
}