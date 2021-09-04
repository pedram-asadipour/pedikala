using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : GenericRepository<Order,long> , IOrderRepository
    {
        private readonly ShopContext _context;
        private readonly AccountContext _accountContext; 

        public OrderRepository(ShopContext context, AccountContext accountContext) : base(context)
        {
            _context = context;
            _accountContext = accountContext;
        }

        public List<OrderViewModel> GetAll(OrderSearchModel searchModel)
        {
            var accounts = _accountContext.Accounts
                .Select(x => new {x.Id,x.Username})
                .AsNoTracking()
                .ToList();

            var query = _context.Orders
                .Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    AccountId = x.AccountId,
                    TotalAmount = x.TotalAmount.ToString("##,###"),
                    DiscountAmount = x.DiscountAmount.ToString("##,###"),
                    PayAmount = x.PayAmount.ToString("##,###"),
                    IsPaid = x.IsPaid,
                    IsProcessing = x.IsProcessing,
                    IssueTrackingNo = x.IssueTrackingNo,
                    RefId = x.RefId,
                    CreationDate = x.CreationDate
                });

            if (searchModel.AccountId > 0)
                query = query.Where(x => x.AccountId == searchModel.AccountId);

            if (!string.IsNullOrWhiteSpace(searchModel.IssueTrackingNo))
                query = query.Where(x => 
                    x.IssueTrackingNo.ToLower() == searchModel.IssueTrackingNo.ToLower());

            if (!string.IsNullOrWhiteSpace(searchModel.CreationDate))
                query = query.Where(x => 
                    x.CreationDate >= searchModel.CreationDate.ToGregorianDate());

            query = query.AsNoTracking();

            query = query.OrderByDescending(x => x.Id);

            var queryViewModel = query.ToList();

            queryViewModel.ForEach(x =>
            {
                x.AccountUsername = accounts.FirstOrDefault(account => account.Id == x.AccountId)?.Username;
            });

            return queryViewModel;
        }

        public List<OrderItemViewModel> GetAllOrderItems(long orderId)
        {
            var products = _context.Products
                .Select(x => new { x.Id, x.Name })
                .AsNoTracking()
                .ToList();

            var orders = _context.Orders
                .Select(x => new { x.Id, x.Items })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == orderId);

            if (orders == null)
                return null;

            var query = orders.Items
                .Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = null,
                    UnitPrice = x.UnitPrice.ToString("##,###"),
                    Count = x.Count,
                    DiscountRate = x.DiscountRate,
                    TotalPrice = x.TotalPrice.ToString("##,###"),
                    DiscountPrice = DiscountPrice(x).ToString("##,###"),
                    Pay = (x.TotalPrice - DiscountPrice(x)).ToString("##,###"),
                    OrderId = x.OrderId,
                })
                .OrderByDescending(x => x.Id)
                .ToList();

            query.ForEach(x =>
            {
                x.ProductName = products.FirstOrDefault(product => product.Id == x.ProductId)?.Name;
            });

            return query;
        }

        private static double DiscountPrice(OrderItem x)
        {
            return (x.TotalPrice * x.DiscountRate) / 100;
        }
    }
}