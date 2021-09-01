using System.Linq;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
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

        public void OnGet()
        {
        }

        public IActionResult OnGetSignOut()
        {
            _application.SignOut();
            return Redirect("./");
        }


        public IActionResult OnPostRegister(RegisterAccount register,string returnUrl)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Register(register);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message;

            return Page();
        }

        public IActionResult OnPostLogIn(LogInAccount logIn)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.LogIn(logIn);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message;

            return json.IsSucceeded ? Redirect("./") : Page();
        }
    }
}