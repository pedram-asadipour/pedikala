using System.Collections.Generic;
using _01_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Areas.Admin.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        public ColleagueDiscountSearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public List<ColleagueDiscountViewModel> ColleagueDiscounts { get; set; }

        private readonly IColleagueDiscountApplication _application;
        private readonly IProductApplication _productApplication;

        public IndexModel(IColleagueDiscountApplication application, IProductApplication productApplication)
        {
            _productApplication = productApplication;
            _application = application;
        }

        [NeedsPermission(DiscountPermissions.ColleagueDiscount)]
        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetAllSelectModel(), "Id", "Name");
            ColleagueDiscounts = _application.GetAll(searchModel);
        }

        [NeedsPermission(DiscountPermissions.ColleagueDiscount)]
        public PartialViewResult OnGetList(ColleagueDiscountSearchModel searchModel)
        {
            ColleagueDiscounts = _application.GetAll(searchModel);
            return Partial("./List", ColleagueDiscounts);
        }

        [NeedsPermission(DiscountPermissions.DefineColleagueDiscount)]
        public PartialViewResult OnGetDefine()
        {
            var defineColleagueDiscount = new DefineColleagueDiscount()
            {
                Products = _productApplication.GetAllSelectModel()
            };

            return Partial("./Define", defineColleagueDiscount);
        }

        [NeedsPermission(DiscountPermissions.DefineColleagueDiscount)]
        public JsonResult OnPostDefine(DefineColleagueDiscount command)
        {
            var json = _application.Define(command);
            return new JsonResult(json);
        }

        [NeedsPermission(DiscountPermissions.EditColleagueDiscount)]
        public PartialViewResult OnGetEdit(long id)
        {
            var colleagueDiscount = _application.GetDetail(id);

            colleagueDiscount.Products = _productApplication.GetAllSelectModel();

            return Partial("./Edit", colleagueDiscount);
        }

        [NeedsPermission(DiscountPermissions.EditColleagueDiscount)]
        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        [NeedsPermission(DiscountPermissions.RemoveRestoreColleagueDiscount)]
        public JsonResult OnGetRemoved(long id)
        {
            var json = _application.Removed(id);
            return new JsonResult(json);
        }

        [NeedsPermission(DiscountPermissions.RemoveRestoreColleagueDiscount)]
        public JsonResult OnGetRestore(long id)
        {
            var json = _application.Restore(id);
            return new JsonResult(json);
        }
    }
}