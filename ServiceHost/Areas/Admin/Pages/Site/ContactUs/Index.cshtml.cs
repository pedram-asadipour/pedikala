using System.Collections.Generic;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Configuration.Permission;

namespace ServiceHost.Areas.Admin.Pages.Site.ContactUs
{
    public class IndexModel : PageModel
    {
        public List<ContactUsViewModel> Massages { get; set; }

        private readonly IContactUsApplication _application;

        public IndexModel(IContactUsApplication application)
        {
            _application = application;
            Massages = new List<ContactUsViewModel>();
        }

        [NeedsPermission(SitePermissions.Messages)]
        public void OnGet()
        {
            Massages = _application.GetMessages();
        }

        [NeedsPermission(SitePermissions.Messages)]
        public PartialViewResult OnGetList()
        {
            Massages = _application.GetMessages();
            return Partial("./List", Massages);
        }

        [NeedsPermission(SitePermissions.Status)]
        public JsonResult OnGetStatus(long id)
        {
            var json = _application.SetStatus(id);
            return new JsonResult(json);
        }
    }
}