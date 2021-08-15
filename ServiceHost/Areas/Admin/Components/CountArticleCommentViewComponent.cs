using CommentManagement.Application.Contract.ArticleComment;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.Components
{
    public class CountArticleCommentViewComponent : ViewComponent
    {
        private readonly IArticleCommentApplication _application;

        public CountArticleCommentViewComponent(IArticleCommentApplication application)
        {
            _application = application;
        }

        public IViewComponentResult Invoke()
        {
            var countCommand = _application.GetCountComments();
            return View(countCommand);
        }
    }
}