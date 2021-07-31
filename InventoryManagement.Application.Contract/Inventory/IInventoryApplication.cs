using System.Collections.Generic;
using _01_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        List<InventoryViewModel> GetAll(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetAllOperations(long inventoryId);
        EditInventory GetDetail(long id);
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(ReduceInventory command);
        OperationResult Reduce(List<ReduceInventory> command);
    }
}