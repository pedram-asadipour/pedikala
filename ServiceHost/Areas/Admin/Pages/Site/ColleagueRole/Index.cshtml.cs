using _01_Framework.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Site.ColleagueRole
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _application;

        public EditColleagueRole Command { get; set; }
        public SelectList Roles { get; set; }

        public IndexModel(IRoleApplication application)
        {
            _application = application;
        }

        [NeedsPermission(AccountPermissions.ColleagueRole)]
        public void OnGet()
        {
            Roles = new SelectList(_application.GetAll(), "Id", "Name");
            Command = _application.GetColleagueRole();
        }

        [NeedsPermission(AccountPermissions.ColleagueRole)]
        public JsonResult OnPost(EditColleagueRole command)
        {
            var json = _application.EditColleagueRole(command);
            return new JsonResult(json);
        }
    }
}
