using CommentManagement.Application.Contract.ProductComment;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.Components
{
    public class CountProductCommentViewComponent :ViewComponent
    {
        private readonly IProductCommentApplication _application;

        public CountProductCommentViewComponent(IProductCommentApplication application)
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