using System.Collections.Generic;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Configuration.Permission;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        public ProductPictureSearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public List<ProductPictureViewModel> ProductPictures { get; set; }

        private readonly IProductPictureApplication _application;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication application, IProductApplication productApplication)
        {
            _application = application;
            _productApplication = productApplication;
        }

        [NeedsPermission(ShopPermissions.ProductPicture)]
        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetAllSelectModel(), "Id", "Name");
            ProductPictures = _application.GetAll(searchModel);
        }

        [NeedsPermission(ShopPermissions.ProductPicture)]
        public PartialViewResult OnGetList(ProductPictureSearchModel searchModel)
        {
            ProductPictures = _application.GetAll(searchModel);
            return Partial("./List", ProductPictures);
        }

        [NeedsPermission(ShopPermissions.CreateProductPicture)]
        public PartialViewResult OnGetCreate()
        {
            var createProductPicture = new CreateProductPicture()
            {
                Products = _productApplication.GetAllSelectModel()
            };

            return Partial("./Create", createProductPicture);
        }

        [NeedsPermission(ShopPermissions.CreateProductPicture)]
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var json = _application.Create(command);
            return new JsonResult(json);
        }

        [NeedsPermission(ShopPermissions.EditProductPicture)]
        public PartialViewResult OnGetEdit(long id)
        {
            var editProductPicture = _application.GetDetail(id);

            editProductPicture.Products = _productApplication.GetAllSelectModel();

            return Partial("./Edit", editProductPicture);
        }

        [NeedsPermission(ShopPermissions.EditProductPicture)]
        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        [NeedsPermission(ShopPermissions.RemoveRestoreProductPicture)]
        public JsonResult OnGetRemoved(long id)
        {
            var json = _application.Removed(id);
            return new JsonResult(json);
        }

        [NeedsPermission(ShopPermissions.RemoveRestoreProductPicture)]
        public JsonResult OnGetRestore(long id)
        {
            var json = _application.Restore(id);
            return new JsonResult(json);
        }
    }
}