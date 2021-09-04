using System.Collections.Generic;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Configuration.Permission;

namespace ServiceHost.Areas.Admin.Pages.Shop.Order
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel { get; set; }
        public SelectList Accounts { get; set; }
        public List<OrderViewModel> Orders { get; set; }

        private readonly IOrderApplication _application;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication application, IAccountApplication accountApplication)
        {
            _application = application;
            _accountApplication = accountApplication;
        }

        [NeedsPermission(ShopPermissions.Orders)]
        public void OnGet(OrderSearchModel searchModel)
        {
            Accounts = new SelectList(_accountApplication.GetAllSelectModel(), "Id", "Name");
            Orders = _application.GetAll(searchModel);
        }

        [NeedsPermission(ShopPermissions.Orders)]
        public PartialViewResult OnGetList(OrderSearchModel searchModel)
        {
            Orders = _application.GetAll(searchModel);
            return Partial("./List", Orders);
        }

        [NeedsPermission(ShopPermissions.OrderProcess)]
        public JsonResult OnGetProcess(long id)
        {
            var result = _application.Process(id);
            return new JsonResult(result);
        }

        [NeedsPermission(ShopPermissions.OrderItems)]
        public PartialViewResult OnGetItems(long id)
        {
            var items = _application.GetAllOrderItems(id);
            return Partial("./Items", items);
        }
    }
}