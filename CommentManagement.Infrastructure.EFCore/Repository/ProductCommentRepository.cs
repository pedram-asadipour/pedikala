using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using CommentManagement.Application.Contract.ProductComment;
using CommentManagement.Domain.ProductCommentAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class ProductCommentRepository : GenericRepository<ProductComment, long>, IProductCommentRepository
    {
        private readonly CommentContext _context;
        private readonly ShopContext _shopContext;

        public ProductCommentRepository(CommentContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public List<ProductCommentViewModel> GetAll(ProductCommentSearchModel search)
        {
            var productQuery = _shopContext.Products
                .Select(x => new {x.Id, x.Name})
                .AsNoTracking()
                .ToList();

            var query = _context.ProductComments
                .Select(x => new ProductCommentViewModel
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
            return _context.ProductComments.Count(x => !x.IsConfirmed && !x.IsCanceled);
        }
    }
}