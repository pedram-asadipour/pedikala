using System.Collections.Generic;
using System.Linq;
using _01_PedikalaQuery.Contract.Inventory;
using InventoryManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.Order;

namespace _01_PedikalaQuery.Query
{
    public class InventoryQuery : IInventoryQuery
    {
        private readonly InventoryContext _inventoryContext;

        public InventoryQuery(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public List<CartItem> CheckInventory(List<CartItem> cartItems)
        {
            var inventories = _inventoryContext.Inventories
                .Select(x => new
                {
                    x.ProductId,
                    x.IsInStock,
                    CurrentCount = x.CalculationCurrentCount()
                })
                .ToList();

            cartItems.ForEach(item =>
            {
                var inventory = inventories.FirstOrDefault(x => x.ProductId == item.Id && x.IsInStock);
                if (inventory != null) 
                    item.IsInStock = inventory.CurrentCount >= item.Count;
            });

            return cartItems;
        }
    }
}