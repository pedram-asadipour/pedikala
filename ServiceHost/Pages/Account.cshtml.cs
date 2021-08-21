using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        public SignInAccount Create { get; set; }
        public LogInAccount LogIn { get; set; }
        [ViewData] public bool StatusMessage { get; set; }
        [ViewData] public string ResultMessage { get; set; }


        private readonly IAccountApplication _application;
        private readonly IAuthHelper _authHelper;

        public AccountModel(IAccountApplication application, IAuthHelper authHelper)
        {
            _application = application;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetSignOut()
        {
            _authHelper.SignOut();
            return Redirect("./");
        }


        public IActionResult OnPostCreate(SignInAccount create)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(create);

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