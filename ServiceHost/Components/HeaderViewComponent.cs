using _01_PedikalaQuery.Contract.Menu;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IMenuQuery _query;

        public HeaderViewComponent(IMenuQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var menus = _query.GetMenus();
            return View(menus);
        }
    }
}
