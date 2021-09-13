using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Configuration.Permission;

namespace ServiceHost.Areas.Admin.Pages.Site.ContactUs
{
    public class EditInfoModel : PageModel
    {
        private readonly IContactUsApplication _application;

        public EditContactUsInfo Command { get; set; }

        public EditInfoModel(IContactUsApplication application)
        {
            _application = application;
        }

        [NeedsPermission(SitePermissions.EditInfo)]
        public void OnGet()
        {
            Command = _application.GetInfo();
        }

        [NeedsPermission(SitePermissions.EditInfo)]
        public JsonResult OnPost(EditContactUsInfo command)
        {
            var json = _application.EditInfo(command);
            return new JsonResult(json);
        }
    }
}
