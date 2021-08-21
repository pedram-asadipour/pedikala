using System.Collections.Generic;
using _01_Framework.Domain;
using AccountManagement.Application.Contract.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IGenericRepository<Account,long>
    {
        List<AccountViewModel> GetAll(AccountSearchModel searchModel);
        EditAccount GetDetail(long id);
        Account GetAccountBy(string username);
    }
}