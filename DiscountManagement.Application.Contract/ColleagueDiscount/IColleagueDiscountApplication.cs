using System.Collections.Generic;
using _01_Framework.Application;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearchModel searchModel);
        EditColleagueDiscount GetDetail(long id);
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        OperationResult Removed(long id);
        OperationResult Restore(long id);
    }
}
