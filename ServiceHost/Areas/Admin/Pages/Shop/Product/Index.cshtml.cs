using System.Collections.Generic;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Configuration.Permission;

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

        [NeedsPermission(ShopPermissions.Product)]
        public void OnGet()
        {
            Categories = new SelectList(_categoryApplication.GetAllSelectModel(), "Id", "Name");
            Products = _application.GetAll(new ProductSearchModel());
        }

        [NeedsPermission(ShopPermissions.Product)]
        public PartialViewResult OnGetList(ProductSearchModel searchModel)
        {
            Products = _application.GetAll(searchModel);
            return Partial("./List", Products);
        }

        [NeedsPermission(ShopPermissions.CreateProduct)]
        public PartialViewResult OnGetCreate()
        {
            var createProduct = new CreateProduct()
            {
                Categories = _categoryApplication.GetAllSelectModel()
            };

            return Partial("./Create", createProduct);
        }

        [NeedsPermission(ShopPermissions.CreateProduct)]
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var json = _application.Create(command);
            return new JsonResult(json);
        }

        [NeedsPermission(ShopPermissions.EditProduct)]
        public PartialViewResult OnGetEdit(long id)
        {
            var editProduct = _application.GetDetail(id);

            editProduct.Categories = _categoryApplication.GetAllSelectModel();

            return Partial("./Edit", editProduct);
        }

        [NeedsPermission(ShopPermissions.EditProduct)]
        public JsonResult OnPostEdit(EditProduct command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        [NeedsPermission(ShopPermissions.RemoveRestoreProduct)]
        public JsonResult OnGetRemoved(long id)
        {
            var json = _application.Removed(id);
            return new JsonResult(json);
        }

        [NeedsPermission(ShopPermissions.RemoveRestoreProduct)]
        public JsonResult OnGetRestore(long id)
        {
            var json = _application.Restore(id);
            return new JsonResult(json);
        }
    }
}