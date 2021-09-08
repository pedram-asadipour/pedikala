using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Account
{
    public class EditAccountModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;

        public AuthViewModel Account { get; set; }
        [ViewData] public bool StatusMessage { get; set; }
        [ViewData] public string ResultMessage { get; set; }

        public EditCurrentAccount Command { get; set; }

        public EditAccountModel(IAuthHelper authHelper, IAccountApplication accountApplication)
        {
            _authHelper = authHelper;
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            Account = _authHelper.GetCurrentAccount();
            Command = _accountApplication.GetDetailCurrentAccount(Account.AccountId);
        }

        public IActionResult OnPostEditAccount(EditCurrentAccount command)
        {
            Account = _authHelper.GetCurrentAccount();
            Command = _accountApplication.GetDetailCurrentAccount(Account.AccountId);

            if (!ModelState.IsValid)
            {
                StatusMessage = false;
                ResultMessage = ValidationMessages.AllRequired;

                return Page();
            }

            command.Id = Account.AccountId;

            var json = _accountApplication.EditCurrentAccount(command);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message + " برای اعمال تغیرات به صورت خودکار از حساب خود خارج می شود";

            return Page();
        }
    }
}
