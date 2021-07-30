using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : GenericRepository<ColleagueDiscount, long>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;


        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products
                .Select(x => new {x.Id, x.Name})
                .ToList();

            var query = _context.ColleagueDiscounts
                .Select(x => new ColleagueDiscountViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                    CreationDate = x.CreationDate.ToPersianDate(),
                    IsRemoved = x.IsRemoved
                });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);


            query = query.AsNoTracking();

            var queryViewModel = query.ToList();

            queryViewModel.ForEach(x => 
                x.ProductName = products.FirstOrDefault(product => product.Id == x.ProductId)?.Name);

            return queryViewModel.ToList();
        }

        public EditColleagueDiscount GetDetail(long id)
        {
            return _context.ColleagueDiscounts
                .Select(x => new EditColleagueDiscount
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}