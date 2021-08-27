using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost.Framework
{
    [HtmlTargetElement(Attributes = "permissions")]
    public class PermissionsTagHelper : TagHelper
    {
        public List<string> Permissions { get; set; }

        private readonly IAuthHelper _authHelper;

        public PermissionsTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var currentAccountPermissions = _authHelper.GetCurrentAccount().Permissions;

            if (currentAccountPermissions.Count == 0)
            {
                output.SuppressOutput();
                return;
            }

            var suppress = Permissions.Sum(permission =>
                (currentAccountPermissions.Any(x => x == permission) ? 1 : 0));

            if (suppress == 0)
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}