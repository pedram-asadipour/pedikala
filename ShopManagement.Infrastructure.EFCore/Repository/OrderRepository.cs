using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : GenericRepository<Order,long> , IOrderRepository
    {
        private readonly ShopContext _context;

        public OrderRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
    }
}