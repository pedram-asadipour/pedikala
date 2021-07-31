using System.Collections.Generic;
using _01_Framework.Domain;
using InventoryManagement.Application.Contract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IGenericRepository<Inventory,long>
    {
        List<InventoryViewModel> GetAll(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetAllOperations(long inventoryId);
        EditInventory GetDetail(long id);
        Inventory GetInventoryBy(long productId);
    }
}