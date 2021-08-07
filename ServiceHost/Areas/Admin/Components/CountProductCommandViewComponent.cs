using CommandManagement.Application.Contract.ProductCommand;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.Components
{
    public class CountProductCommandViewComponent :ViewComponent
    {
        private readonly IProductCommandApplication _application;

        public CountProductCommandViewComponent(IProductCommandApplication application)
        {
            _application = application;
        }

        public IViewComponentResult Invoke()
        {
            var countCommand = _application.GetCountCommand();
            return View(countCommand);
        }
    }
}