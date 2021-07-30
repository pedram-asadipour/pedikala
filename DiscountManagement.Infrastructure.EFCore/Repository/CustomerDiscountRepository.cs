using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : GenericRepository<CustomerDiscount, long>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }


        public List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products
                .Select(x => new {x.Id, x.Name})
                .AsNoTracking()
                .ToList();

            IQueryable<CustomerDiscount> query = _context.CustomerDiscounts;

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
                query = query.Where(x => x.StartDate >= searchModel.StartDate.ToGregorianDate());

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
                query = query.Where(x => x.EndDate <= searchModel.EndDate.ToGregorianDate());

            var viewModelQuery = query
                .Select(x => new CustomerDiscountViewModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                    StartDate = x.StartDate.ToPersianDate(),
                    EndDate = x.EndDate.ToPersianDate(),
                    DiscountStatus = DateTools.DateChecker(x.StartDate,x.EndDate) && !x.IsRemoved,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToPersianDate(),
                })
                .AsNoTracking()
                .ToList();

            viewModelQuery.ForEach(x =>
                x.ProductName = products.FirstOrDefault(product => product.Id == x.ProductId)?.Name);


            return viewModelQuery;
        }

        public EditCustomerDiscount GetDetail(long id)
        {
            return _context.CustomerDiscounts
                .Select(x => new EditCustomerDiscount
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountRate = x.DiscountRate,
                    StartDate = x.StartDate.ToString(CultureInfo.InvariantCulture),
                    EndDate = x.EndDate.ToString(CultureInfo.InvariantCulture),
                    Reason = x.Reason
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}