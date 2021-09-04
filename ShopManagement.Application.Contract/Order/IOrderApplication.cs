using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Application.Contract.Order
{
    public interface IOrderApplication
    {
        List<OrderViewModel> GetAll(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetAllOrderItems(long orderId);
        OperationResult Process(long orderId);
        long PlaceOrder(Cart cart);
        string PaySucceeded(long orderId,long refId);
        void DeleteOrderBy(long orderId);
    }
}