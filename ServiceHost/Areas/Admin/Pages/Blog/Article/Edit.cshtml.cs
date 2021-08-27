using _01_Framework.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Blog.Article
{
    public class EditModel : PageModel
    {
        public EditArticle Command { get; set; }
        public SelectList Categories { get; set; }

        private readonly IArticleApplication _application;
        private readonly IArticleCategoryApplication _categoryApplication;

        public EditModel(IArticleApplication application, IArticleCategoryApplication categoryApplication)
        {
            _application = application;
            _categoryApplication = categoryApplication;
        }

        [NeedsPermission(BlogPermissions.EditArticle)]
        public IActionResult OnGet(long id)
        {
            Command = _application.GetDetail(id);

            if (Command == null)
                return NotFound();

            Categories = new SelectList(_categoryApplication.GetAllSelectModel(), "Id", "Name");
            return Page();
        }

        [NeedsPermission(BlogPermissions.EditArticle)]
        public IActionResult OnPost(EditArticle command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Edit(command);
            return new JsonResult(json);
        }
    }
}
