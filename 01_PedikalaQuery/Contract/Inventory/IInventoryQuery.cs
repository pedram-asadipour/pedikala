using System.Collections.Generic;
using InventoryManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.Order;

namespace _01_PedikalaQuery.Contract.Inventory
{
    public interface IInventoryQuery
    {
        List<CartItem> CheckInventory(List<CartItem> cartItems);
    }
}