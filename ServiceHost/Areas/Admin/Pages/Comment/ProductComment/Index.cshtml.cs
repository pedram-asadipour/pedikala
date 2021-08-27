using System.Collections.Generic;
using _01_Framework.Application;
using CommentManagement.Application.Contract.ProductComment;
using CommentManagement.Configuration.Permission;
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

        [NeedsPermission(CommentPermissions.ProductComment)]
        public void OnGet(ProductCommentSearchModel searchModel)
        {
            Commands = _application.GetAll(searchModel);
        }

        [NeedsPermission(CommentPermissions.ProductComment)]
        public PartialViewResult OnGetList(ProductCommentSearchModel searchModel)
        {
            Commands = _application.GetAll(searchModel);
            return Partial("./List", Commands);
        }

        [NeedsPermission(CommentPermissions.ConfirmCancelProductComment)]
        public JsonResult OnGetConfirmed(long id)
        {
            var json = _application.Confirmed(id);
            return new JsonResult(json);
        }

        [NeedsPermission(CommentPermissions.ConfirmCancelProductComment)]
        public JsonResult OnGetCanceled(long id)
        {
            var json = _application.Canceled(id);
            return new JsonResult(json);
        }
    }
}