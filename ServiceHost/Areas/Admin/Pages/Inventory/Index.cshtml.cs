using System.Collections.Generic;
using _01_Framework.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Areas.Admin.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        public InventorySearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public List<InventoryViewModel> Inventories { get; set; }

        private readonly IInventoryApplication _application;
        private readonly IProductApplication _productApplication;

        public IndexModel(IInventoryApplication application, IProductApplication productApplication)
        {
            _application = application;
            _productApplication = productApplication;
        }

        [NeedsPermission(InventoryPermissions.Inventory)]
        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetAllSelectModel(), "Id", "Name");
            Inventories = _application.GetAll(searchModel);
        }

        [NeedsPermission(InventoryPermissions.Inventory)]
        public PartialViewResult OnGetList(InventorySearchModel searchModel)
        {
            Inventories = _application.GetAll(searchModel);
            return Partial("./List", Inventories);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public PartialViewResult OnGetCreate()
        {
            var createInventory = new CreateInventory()
            {
                Products = _productApplication.GetAllSelectModel()
            };

            return Partial("./Create", createInventory);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var json = _application.Create(command);
            return new JsonResult(json);
        }

        [NeedsPermission(InventoryPermissions.EditInventory)]
        public PartialViewResult OnGetEdit(long id)
        {
            var editInventory = _application.GetDetail(id);

            editInventory.Products = _productApplication.GetAllSelectModel();

            return Partial("./Edit", editInventory);
        }

        [NeedsPermission(InventoryPermissions.EditInventory)]
        public JsonResult OnPostEdit(EditInventory command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        [NeedsPermission(InventoryPermissions.IncreaseInventory)]
        public PartialViewResult OnGetIncrease(long id)
        {
            var increaseInventory = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("./Increase", increaseInventory);
        }

        [NeedsPermission(InventoryPermissions.IncreaseInventory)]
        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var json = _application.Increase(command);
            return new JsonResult(json);
        }

        [NeedsPermission(InventoryPermissions.ReduceInventory)]
        public PartialViewResult OnGetReduce(long id)
        {
            var reduceInventory = new ReduceInventory()
            {
                InventoryId = id
            };
            return Partial("./Reduce", reduceInventory);
        }

        [NeedsPermission(InventoryPermissions.ReduceInventory)]
        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var json = _application.Reduce(command);
            return new JsonResult(json);
        }

        [NeedsPermission(InventoryPermissions.ListOperationLog)]
        public PartialViewResult OnGetOperationLog(long id)
        {
            var operationLog = _application.GetAllOperations(id);
            return Partial("./OperationLog", operationLog);
        }
    }
}