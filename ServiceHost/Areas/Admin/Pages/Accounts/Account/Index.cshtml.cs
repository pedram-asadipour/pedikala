using System.Collections.Generic;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel { get; set; }
        public SelectList Roles { get; set; }
        public List<AccountViewModel> Accounts { get; set; }

        private readonly IAccountApplication _application;
        private readonly IRoleApplication _roleApplication;

        public IndexModel(IAccountApplication application,IRoleApplication roleApplication)
        {
            _application = application;
            _roleApplication = roleApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.GetAll(), "Id", "Name");
            Accounts = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(AccountSearchModel searchModel)
        {
            Accounts = _application.GetAll(searchModel);
            return Partial("./List", Accounts);
        }

        public PartialViewResult OnGetCreate()
        {
            var createAccount = new CreateAccount()
            {
                Roles = _roleApplication.GetAll()
            };

            return Partial("./Create", createAccount);
        }

        public JsonResult OnPostCreate(CreateAccount command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(command);
            return new JsonResult(json);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var editAccount = _application.GetDetail(id);

            editAccount.Roles = _roleApplication.GetAll();

            return Partial("./Edit", editAccount);
        }

        public JsonResult OnPostEdit(EditAccount command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        public PartialViewResult OnGetChangePassword(long id)
        {
            var account = new ChangePasswordAccount()
            {
                Id = id
            };

            return Partial("./ChangePassword",account);
        }

        public JsonResult OnPostChangePassword(ChangePasswordAccount command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.ChangePassword(command);
            return new JsonResult(json);
        }
    }
}