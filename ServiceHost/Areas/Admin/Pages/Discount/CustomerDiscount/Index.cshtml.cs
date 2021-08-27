using System.Collections.Generic;
using _01_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Areas.Admin.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        public CustomerDiscountSearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }

        private readonly ICustomerDiscountApplication _application;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDiscountApplication application, IProductApplication productApplication)
        {
            _application = application;
            _productApplication = productApplication;
        }

        [NeedsPermission(DiscountPermissions.CustomerDiscount)]
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetAllSelectModel(), "Id", "Name");
            CustomerDiscounts = _application.GetAll(searchModel);
        }

        [NeedsPermission(DiscountPermissions.CustomerDiscount)]
        public PartialViewResult OnGetList(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscounts = _application.GetAll(searchModel);
            return Partial("./List", CustomerDiscounts);
        }

        [NeedsPermission(DiscountPermissions.DefineCustomerDiscount)]
        public PartialViewResult OnGetDefine()
        {
            var defineCustomerDiscount = new DefineCustomerDiscount()
            {
                Products = _productApplication.GetAllSelectModel()
            };

            return Partial("./Define", defineCustomerDiscount);
        }

        [NeedsPermission(DiscountPermissions.DefineCustomerDiscount)]
        public JsonResult OnPostDefine(DefineCustomerDiscount command)
        {
            var json = _application.Define(command);
            return new JsonResult(json);
        }

        [NeedsPermission(DiscountPermissions.EditCustomerDiscount)]
        public PartialViewResult OnGetEdit(long id)
        {
            var customerDiscount = _application.GetDetail(id);

            customerDiscount.Products = _productApplication.GetAllSelectModel();

            return Partial("./Edit", customerDiscount);
        }

        [NeedsPermission(DiscountPermissions.EditCustomerDiscount)]
        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        [NeedsPermission(DiscountPermissions.RemoveRestoreCustomerDiscount)]
        public JsonResult OnGetRemoved(long id)
        {
            var json = _application.Removed(id);
            return new JsonResult(json);
        }

        [NeedsPermission(DiscountPermissions.RemoveRestoreCustomerDiscount)]
        public JsonResult OnGetRestore(long id)
        {
            var json = _application.Restore(id);
            return new JsonResult(json);
        }
    }
}