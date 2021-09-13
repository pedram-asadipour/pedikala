using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Contract.ContactUs;

namespace ServiceHost.Areas.Admin.Components
{
    public class CountMessageComponent : ViewComponent
    {
        private readonly IContactUsApplication _application;

        public CountMessageComponent(IContactUsApplication application)
        {
            _application = application;
        }

        public IViewComponentResult Invoke()
        {
            var count = _application.GetMessagesCount();
            return View(count);
        }
    }
}