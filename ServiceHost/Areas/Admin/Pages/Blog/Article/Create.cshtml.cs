using _01_Framework.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Blog.Article
{
    public class CreateModel : PageModel
    {
        public CreateArticle Command { get; set; }
        public SelectList Categories { get; set; }

        private readonly IArticleApplication _application;
        private readonly IArticleCategoryApplication _categoryApplication;

        public CreateModel(IArticleApplication application, IArticleCategoryApplication categoryApplication)
        {
            _application = application;
            _categoryApplication = categoryApplication;
        }

        [NeedsPermission(BlogPermissions.CreateArticle)]
        public void OnGet()
        {
            Categories = new SelectList(_categoryApplication.GetAllSelectModel(), "Id", "Name");
        }

        [NeedsPermission(BlogPermissions.CreateArticle)]
        public IActionResult OnPost(CreateArticle command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(command);
            return new JsonResult(json);
        }
    }
}
