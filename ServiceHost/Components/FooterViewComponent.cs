using _01_PedikalaQuery.Contract.Footer;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IFooterQuery _query;

        public FooterViewComponent(IFooterQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _query.GetFooter();
            return View(footer);
        }
    }
}