using System.Collections.Generic;
using _01_Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel);
        EditCustomerDiscount GetDetail(long id);
        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        OperationResult Removed(long id);
        OperationResult Restore(long id);
    }
}