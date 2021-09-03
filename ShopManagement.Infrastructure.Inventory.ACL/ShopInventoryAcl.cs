using System.Collections.Generic;
using InventoryManagement.Application.Contract.Inventory;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infrastructure.Inventory.ACL
{
    public class ShopInventoryAcl : IShopInventoryAcl
    {
        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool ReduceFromInventory(List<OrderItem> items)
        {
            var reduces =  new List<ReduceInventory>();

            foreach (var orderItem in items)
            {
                var reduce = new ReduceInventory(orderItem.ProductId,orderItem.Count,"خرید مشتری",orderItem.OrderId);

                reduces.Add(reduce);
            }

            return _inventoryApplication.Reduce(reduces).IsSucceeded;
        }
    }
}
