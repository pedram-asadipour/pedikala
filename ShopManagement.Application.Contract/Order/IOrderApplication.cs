namespace ShopManagement.Application.Contract.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        string PaySucceeded(long orderId,long refId);
        void DeleteOrderBy(long orderId);
    }
}