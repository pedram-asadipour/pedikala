using _01_PedikalaQuery.Contract.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class LastArticleComponent : ViewComponent
    {
        private readonly IArticleQuery _query;

        public LastArticleComponent(IArticleQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var lastArticles = _query.GetLastArticles();
            return View(lastArticles);
        }
    }
}