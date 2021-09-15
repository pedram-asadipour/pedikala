using System.Collections.Generic;
using System.Linq;
using _01_PedikalaQuery.Contract.Inventory;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class InventoryQuery : IInventoryQuery
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryQuery(InventoryContext inventoryContext, ShopContext shopContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
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

        public StockResult CheckInventoryStock(CheckInventoryStock command)
        {
            var inventory = _inventoryContext.Inventories
                .Select(x => new {x.ProductId, calculationCurrentCount = x.CalculationCurrentCount() })
                .FirstOrDefault(x => x.ProductId == command.ProductId);


            if (inventory == null || inventory.calculationCurrentCount < command.Count)
            {
                var productName = _shopContext.Products
                    .Select(x => new { x.Id, x.Name })
                    .FirstOrDefault(x => x.Id == command.ProductId)?.Name;

                return new StockResult
                {
                    InStock = false,
                    ProductName = productName
                };
            }

            return new StockResult()
            {
                InStock = true
            };
        }
    }
}