using System.Collections.Generic;
using _01_Framework.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
        public SelectList Categories { get; set; }

        private readonly IArticleApplication _application;
        private readonly IArticleCategoryApplication _categoryApplication;

        public IndexModel(IArticleApplication application, IArticleCategoryApplication categoryApplication)
        {
            _application = application;
            _categoryApplication = categoryApplication;
        }

        [NeedsPermission(BlogPermissions.Article)]
        public void OnGet(ArticleSearchModel searchModel)
        {
            Categories = new SelectList(_categoryApplication.GetAllSelectModel(), "Id", "Name");
            Articles = _application.GetAll(searchModel);
        }
    }
}