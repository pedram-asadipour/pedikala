using System.Collections.Generic;
using ShopManagement.Application.Contract.Order;

namespace _01_PedikalaQuery.Contract.Cart
{
    public interface ICartQuery
    {
        ShopManagement.Application.Contract.Order.Cart ComputeCart(List<CartItem> cartItems);
    }
}