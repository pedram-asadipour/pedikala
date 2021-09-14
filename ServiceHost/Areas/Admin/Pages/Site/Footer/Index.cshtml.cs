using System.Collections.Generic;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteManagement.Application.Contract.Footer;
using SiteManagement.Configuration.Permission;

namespace ServiceHost.Areas.Admin.Pages.Site.Footer
{
    public class IndexModel : PageModel
    {
        public List<FooterLinkViewModel> Links { get; set; }
        public EditFooter Command { get; set; }

        private readonly IFooterApplication _application;

        public IndexModel(IFooterApplication application)
        {
            _application = application;
            Command = _application.GetFooter();
            Links = new List<FooterLinkViewModel>();
        }

        [NeedsPermission(SitePermissions.FooterLink)]
        public void OnGet()
        {
            Links = _application.GetFooterLinks();
        }

        [NeedsPermission(SitePermissions.FooterLink)]
        public PartialViewResult OnGetList()
        {
            Links = _application.GetFooterLinks();
            return Partial("./List", Links);
        }

        [NeedsPermission(SitePermissions.EditFooter)]
        public JsonResult OnPostEditFooter(EditFooter command)
        {
            var json = _application.EditFooter(command);
            return new JsonResult(json);
        }

        [NeedsPermission(SitePermissions.CreateLink)]
        public PartialViewResult OnGetCreateLink()
        {
            return Partial("./CreateLink",new  CreateFooterLink());
        }

        [NeedsPermission(SitePermissions.CreateLink)]
        public JsonResult OnPostCreateLink(CreateFooterLink command)
        {
            var json = _application.CreateLink(command);
            return new JsonResult(json);
        }

        [NeedsPermission(SitePermissions.EditLink)]
        public PartialViewResult OnGetEditLink(long id)
        {
            var editFooterLink = _application.GetFooterLink(id);
            return Partial("./EditLink", editFooterLink);
        }

        [NeedsPermission(SitePermissions.EditLink)]
        public JsonResult OnPostEditLink(EditFooterLink command)
        {
            var json = _application.EditLink(command);
            return new JsonResult(json);
        }

        [NeedsPermission(SitePermissions.RemoveRestoreLink)]
        public JsonResult OnGetRemove(long id)
        {
            var json = _application.RemoveLink(id);
            return new JsonResult(json);
        }

        [NeedsPermission(SitePermissions.RemoveRestoreLink)]
        public JsonResult OnGetRestore(long id)
        {
            var json = _application.RestoreLink(id);
            return new JsonResult(json);
        }
    }
}