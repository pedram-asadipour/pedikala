using System.Linq;
using _01_Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost.Framework
{
    [HtmlTargetElement(Attributes = "permission")]
    public class PermissionTagHelper : TagHelper
    {
        public string Permission { get; set; }

        private readonly IAuthHelper _authHelper;

        public PermissionTagHelper(IAuthHelper authHelper)
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

            if (currentAccountPermissions.All(permission => permission != Permission))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}