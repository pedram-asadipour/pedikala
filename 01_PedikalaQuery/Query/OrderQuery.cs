using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Order;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly ShopContext _context;

        public OrderQuery(ShopContext context)
        {
            _context = context;
        }

        public List<OrderQueryModel> GetOrderBy(long accountId)
        {
            var products = _context.Products
                .Select(x => new {x.Id, x.Name})
                .AsNoTracking()
                .ToList();

            var query = _context.Orders
                .Where(x => x.AccountId == accountId && x.IsPaid)
                .Select(x => new OrderQueryModel
                {
                    Id = x.Id,
                    AccountId = x.Id,
                    PayAmount = x.PayAmount.ToString("##,###"),
                    IsProcessing = x.IsProcessing,
                    IssueTrackingNo = x.IssueTrackingNo,
                    RefId = x.RefId,
                    CreationDate = x.CreationDate.ToPersianDate(),
                    Items = MappingItems(x.Items)
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList();


            query.ForEach(x =>
            {
                x.Items.ForEach(z =>
                {
                    z.ProductName = products.FirstOrDefault(product => product.Id == z.ProductId)?.Name;
                });
            });


            return query;
        }

        private static List<OrderItemQueryModel> MappingItems(IEnumerable<OrderItem> items)
        {
           return items
                .Select(x => new OrderItemQueryModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = null,
                    UnitPrice = x.UnitPrice.ToString("##,###"),
                    Count = x.Count,
                    DiscountRate = x.DiscountRate,
                    Pay = FinalPay(x).ToString("##,###")
                })
                .ToList();
        }

        private static double FinalPay(OrderItem x)
        {
            var totalPrice = x.UnitPrice * x.Count;
            var discountPrice = (totalPrice * x.DiscountRate) / 100;
            return totalPrice - discountPrice;
        }
    }
}