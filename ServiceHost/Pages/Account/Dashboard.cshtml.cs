using _01_Framework.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Account
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly IAuthHelper _authHelper;

        public DashboardModel(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public AuthViewModel Account { get; set; }

        public void OnGet()
        {
            Account = _authHelper.GetCurrentAccount();
        }
    }
}
