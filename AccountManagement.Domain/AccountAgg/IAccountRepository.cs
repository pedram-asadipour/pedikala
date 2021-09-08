using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Domain;
using AccountManagement.Application.Contract.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IGenericRepository<Account,long>
    {
        List<AccountViewModel> GetAll(AccountSearchModel searchModel);
        List<SelectModel> GetAllSelectModel();
        EditAccount GetDetail(long id);
        EditCurrentAccount GetDetailCurrentAccount(long id);
        Account GetAccountBy(string username);
    }
}