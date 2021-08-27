using System.Linq;
using System.Reflection;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost.Framework
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission = (NeedsPermissionAttribute) 
                context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedsPermissionAttribute));

            if(handlerPermission == null)
                return;

            var permission = handlerPermission?.Permission;
            var currentAccountPermissions = _authHelper.GetCurrentAccount().Permissions;

            if(currentAccountPermissions.All(code => code != permission))
                context.HttpContext.Response.Redirect("/NotFound");
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }
    }
}