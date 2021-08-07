using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using CommandManagement.Application.Contract.ProductCommand;
using CommandManagement.Domain.ProductCommandAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace CommandManagement.Infrastructure.EFCore.Repository
{
    public class ProductCommandRepository : GenericRepository<ProductCommand, long>, IProductCommandRepository
    {
        private readonly CommandContext _context;
        private readonly ShopContext _shopContext;

        public ProductCommandRepository(CommandContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public List<ProductCommandViewModel> GetAll(ProductCommandSearchModel search)
        {
            var productQuery = _shopContext.Products
                .Select(x => new {x.Id, x.Name})
                .AsNoTracking()
                .ToList();

            var query = _context.ProductCommands
                .Select(x => new ProductCommandViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToPersianDate(),
                    IsConfirmed = x.IsConfirmed,
                    IsCanceled = x.IsCanceled
                });

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));

            if (!string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(x => x.Email.Contains(search.Email));

            query = query.OrderByDescending(x => x.Id);
            query = query.AsNoTracking();

            var queryViewModel = query.ToList();

            queryViewModel.ForEach(x => 
                x.ProductName = productQuery.FirstOrDefault(product => product.Id == x.ProductId)?.Name);

            return queryViewModel.ToList();
        }

        public int GetCountCommand()
        {
            return _context.ProductCommands.Count(x => !x.IsConfirmed && !x.IsCanceled);
        }
    }
}