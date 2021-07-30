using System.Collections.Generic;
using _01_Framework.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IGenericRepository<CustomerDiscount,long>
    {
        List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel);
        EditCustomerDiscount GetDetail(long id);
    }
}