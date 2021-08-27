using System.Collections.Generic;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [NeedsPermission(AccountPermissions.Role)]
        public void OnGet()
        {
            Roles = _application.GetAll();
        }

        [NeedsPermission(AccountPermissions.Role)]
        public PartialViewResult OnGetList()
        {
            Roles = _application.GetAll();
            return Partial("./List", Roles);
        }

        [NeedsPermission(AccountPermissions.CreateRole)]
        public PartialViewResult OnGetCreate()
        {
            var createRole = new CreateRole()
            {
                Permissions = _application.GetPermissions(new List<string>())
            };

            return Partial("./Create", createRole);
        }

        [NeedsPermission(AccountPermissions.CreateRole)]
        public JsonResult OnPostCreate(CreateRole command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(command);
            return new JsonResult(json);
        }

        [NeedsPermission(AccountPermissions.EditRole)]
        public PartialViewResult OnGetEdit(long id)
        {
            var editRole = _application.GetDetail(id);

            editRole.Permissions.AddRange(_application.GetPermissions(editRole.Permission));

            return Partial("./Edit", editRole);
        }

        [NeedsPermission(AccountPermissions.EditRole)]
        public JsonResult OnPostEdit(EditRole command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Edit(command);
            return new JsonResult(json);
        }
    }
}