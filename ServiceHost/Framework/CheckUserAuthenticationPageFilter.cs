using System.Reflection;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost.Framework
{
    public class CheckUserAuthenticationPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public CheckUserAuthenticationPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPageRedirect = (UserAuthenticationAttribute)
                context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(UserAuthenticationAttribute));

            if (!_authHelper.IsAuthenticated()) return;

            if (handlerPageRedirect != null)
                context.HttpContext.Response.Redirect(handlerPageRedirect.PageRedirect);
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }
    }
}