using System.Collections.Generic;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Accounts.Role
{
    public class IndexModel : PageModel
    {
        public List<RoleViewModel> Roles { get; set; }

        private readonly IRoleApplication _application;

        public IndexModel(IRoleApplication application)
        {
            _application = application;
        }

        public void OnGet()
        {
            Roles = _application.GetAll();
        }

        public PartialViewResult OnGetList()
        {
            Roles = _application.GetAll();
            return Partial("./List", Roles);
        }

        public PartialViewResult OnGetCreate()
        {
            return Partial("./Create", new CreateRole());
        }

        public JsonResult OnPostCreate(CreateRole command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(command);
            return new JsonResult(json);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var editRole = _application.GetDetail(id);
            return Partial("./Edit", editRole);
        }

        public JsonResult OnPostEdit(EditRole command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Edit(command);
            return new JsonResult(json);
        }
    }
}