using System.Collections.Generic;
using CommentManagement.Application.Contract.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Comment.ProductComment
{
    public class IndexModel : PageModel
    {
        public ProductCommentSearchModel SearchModel { get; set; }
        public List<ProductCommentViewModel> Commands { get; set; }

        private readonly IProductCommentApplication _application;

        public IndexModel(IProductCommentApplication application)
        {
            _application = application;
        }

        public void OnGet(ProductCommentSearchModel searchModel)
        {
            Commands = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(ProductCommentSearchModel searchModel)
        {
            Commands = _application.GetAll(searchModel);
            return Partial("./List", Commands);
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