using System.Collections.Generic;
using CommentManagement.Application.Contract.ArticleComment;
using CommentManagement.Application.Contract.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Comment.ArticleComment
{
    public class IndexModel : PageModel
    {
        public ArticleCommentSearchModel SearchModel { get; set; }
        public List<ArticleCommentViewModel> Comments { get; set; }

        private readonly IArticleCommentApplication _application;

        public IndexModel(IArticleCommentApplication application)
        {
            _application = application;
        }

        public void OnGet(ArticleCommentSearchModel searchModel)
        {
            Comments = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(ArticleCommentSearchModel searchModel)
        {
            Comments = _application.GetAll(searchModel);
            return Partial("./List", Comments);
        }

        public JsonResult OnGetConfirmed(long id)
        {
            var json = _application.Confirmed(id);
            return new JsonResult(json);
        }

        public JsonResult OnGetCanceled(long id)
        {
            var json = _application.Canceled(id);
            return new JsonResult(json);
        }
    }
}