using System.Collections.Generic;
using _01_Framework.Domain;
using DiscountManagement.Application.Contract.ColleagueDiscount;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IGenericRepository<ColleagueDiscount,long>
    {
        List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearchModel searchModel);
        EditColleagueDiscount GetDetail(long id);
    }
}