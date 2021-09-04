using System.Collections.Generic;
using _01_Framework.Domain;
using ShopManagement.Application.Contract.Order;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository : IGenericRepository<Order,long>
    {
        List<OrderViewModel> GetAll(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetAllOrderItems(long orderId);
    }
}