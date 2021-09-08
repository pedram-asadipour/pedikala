using System.Collections.Generic;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        List<AccountViewModel> GetAll(AccountSearchModel searchModel);
        List<SelectModel> GetAllSelectModel();
        EditAccount GetDetail(long id);
        EditCurrentAccount GetDetailCurrentAccount(long id);
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult EditCurrentAccount(EditCurrentAccount command);
        OperationResult ChangePassword(ChangePasswordAccount command);
        OperationResult ChangePasswordCurrentAccount(ChangePasswordCurrentAccount command);
        OperationResult LogIn(LogInAccount command);
        void SignOut();
    }
}