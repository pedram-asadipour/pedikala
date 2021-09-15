using System.Collections.Generic;
using _01_Framework.Application;
using AccountManagement.Domain.RoleAgg;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _repository;
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IShopInventoryAcl _inventoryAcl;
        private readonly IColleagueRoleRepository _colleagueRoleRepository;

        public OrderApplication(IOrderRepository repository, IAuthHelper authHelper, IConfiguration configuration, IShopInventoryAcl inventoryAcl, IColleagueRoleRepository colleagueRoleRepository)
        {
            _repository = repository;
            _authHelper = authHelper;
            _configuration = configuration;
            _inventoryAcl = inventoryAcl;
            _colleagueRoleRepository = colleagueRoleRepository;
        }

        public List<OrderViewModel> GetAll(OrderSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public List<OrderItemViewModel> GetAllOrderItems(long orderId)
        {
            return _repository.GetAllOrderItems(orderId);
        }

        public OperationResult Process(long orderId)
        {
            var operationResult = new OperationResult();
            var order = _repository.GetBy(orderId);

            if (order == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            order.Process();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public long PlaceOrder(Cart cart)
        {
            var accountId = _authHelper.GetCurrentAccount().AccountId;
            var status = _authHelper.GetCurrentAccount().RoleId == _colleagueRoleRepository.GetColleagueRole().RoleId;

            var order = new Order(accountId,status,cart.TotalAmounts,cart.Pay,cart.TotalDiscounts);

            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new OrderItem(cartItem.Id,cartItem.UnitPrice,cartItem.Count,cartItem.TotalPrice,cartItem.DiscountRate);
                order.AddItem(orderItem);
            }

            _repository.Create(order);

            _repository.SaveChange();

            return order.Id;
        }

        public string PaySucceeded(long orderId, long refId)
        {
            var order = _repository.GetBy(orderId);

            var symbol = _configuration.GetSection("Symbol").Value;

            order.PaySucceeded(refId,Generator.CreateCode(symbol));

            _repository.SaveChange();

            _inventoryAcl.ReduceFromInventory(order.Items);

            return order.IssueTrackingNo;
        }

        public void DeleteOrderBy(long orderId)
        {
            var order = _repository.GetBy(orderId);
            _repository.Delete(order);
            _repository.SaveChange();
        }
    }
}