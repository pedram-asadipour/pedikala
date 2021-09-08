using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;

        public AuthViewModel Account { get; set; }
        [ViewData] public bool StatusMessage { get; set; }
        [ViewData] public string ResultMessage { get; set; }

        public ChangePasswordCurrentAccount Command { get; set; }

        public ChangePasswordModel(IAuthHelper authHelper, IAccountApplication accountApplication)
        {
            _authHelper = authHelper;
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            Account = _authHelper.GetCurrentAccount();
        }

        public IActionResult OnPostChangePassword(ChangePasswordCurrentAccount command)
        {
            Account = _authHelper.GetCurrentAccount();

            if (!ModelState.IsValid)
            {
                StatusMessage = false;
                ResultMessage = ValidationMessages.AllRequired;

                return Page();
            }

            command.Id = Account.AccountId;

            var json = _accountApplication.ChangePasswordCurrentAccount(command);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message;

            return Page();
        }
    }
}
