using System.Collections.Generic;
using _01_Framework.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel SearchModel { get; set; }
        public List<ArticleCategoryViewModel> Categories { get; set; }

        private readonly IArticleCategoryApplication _application;

        public IndexModel(IArticleCategoryApplication application)
        {
            _application = application;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            Categories = _application.GetAll(searchModel);
        }

        public PartialViewResult OnGetList(ArticleCategorySearchModel searchModel)
        {
            Categories = _application.GetAll(searchModel);
            return Partial("./List", Categories);
        }

        public PartialViewResult OnGetCreate()
        {
            return Partial("./Register", new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            if(!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(command);
            return new JsonResult(json);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var editArticleCategory = _application.GetDetail(id);
            return Partial("./Edit", editArticleCategory);
        }

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var json = _application.Edit(command);
            return new JsonResult(json);
        }
    }
}