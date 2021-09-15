using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Account
{
    public class AccountModel : PageModel
    {
        public RegisterAccount Register { get; set; }
        public LogInAccount LogIn { get; set; }
        [ViewData] public bool StatusMessage { get; set; }
        [ViewData] public string ResultMessage { get; set; }

        private readonly IAccountApplication _application;

        public AccountModel(IAccountApplication application)
        {
            _application = application;
        }

        [UserAuthentication("/Account/Dashboard")]
        public void OnGet()
        {
        }

        public IActionResult OnGetSignOut()
        {
            _application.SignOut();
            return Redirect("./");
        }

        [UserAuthentication("/Account/Dashboard")]
        public IActionResult OnPostRegister(RegisterAccount register)
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = false;
                ResultMessage = ValidationMessages.AllRequired;

                return Page();
            }

            var json = _application.Register(register);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message;

            return Page();
        }

        [UserAuthentication("/Account/Dashboard")]
        public IActionResult OnPostLogIn(LogInAccount logIn)
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = false;
                ResultMessage = ValidationMessages.AllRequired;

                return Page();
            }

            var json = _application.LogIn(logIn);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message;
            
            return json.IsSucceeded ? Redirect("./") : Page();
        }
    }
}