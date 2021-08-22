using System.Collections.Generic;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        List<AccountViewModel> GetAll(AccountSearchModel searchModel);
        EditAccount GetDetail(long id);
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePasswordAccount command);
        OperationResult LogIn(LogInAccount command);
        void SignOut();
    }
}