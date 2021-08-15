using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Article;
using _01_PedikalaQuery.Contract.ArticleCategory;
using CommentManagement.Application.Contract.ArticleComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        [BindProperty] public CreateArticleComment Command { get; set; }
        public ArticleQueryModel Article { get; set; }
        public List<SimpleArticleCategoryQueryModel> SimpleCategories { get; set; }
        public List<ArticleMiniWrapQueryModel> LastArticles { get; set; }
        [ViewData] public string CommandStatusMessage { get; set; }
        [ViewData] public bool IsCommandSend { get; set; }

        private readonly IArticleQuery _query;
        private readonly IArticleCategoryQuery _categoryQuery;
        private readonly IArticleCommentApplication _application;

        public ArticleModel(IArticleQuery query, IArticleCategoryQuery categoryQuery,
            IArticleCommentApplication application)
        {
            _query = query;
            _categoryQuery = categoryQuery;
            _application = application;
        }

        public IActionResult OnGet(long id, string slug)
        {
            if (id == 0)
                return NotFound();

            Article = _query.GetArticleBy(id);

            if (Article == null)
                return NotFound();

            SimpleCategories = _categoryQuery.GetSimpleCategories();
            LastArticles = _query.GetLastArticles();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CommandStatusMessage = "همه فیلد ها برای نظر درباره محصول اجباری می باشد";

                IsCommandSend = false;

                Article = _query.GetArticleBy(Command.ArticleId);

                if (Article == null)
                    return NotFound();

                return Page();
            }

            var json = _application.Create(Command);

            CommandStatusMessage = json.IsSucceeded switch
            {
                true => "نظر شما با موفقیت ثبت شد و در صف برسی قرار گرفت",
                false => "نظر شما ثبت نشد"
            };

            IsCommandSend = json.IsSucceeded switch
            {
                true => true,
                false => false
            };

            Article = _query.GetArticleBy(Command.ArticleId);

            if (Article == null)
                return NotFound();

            SimpleCategories = _categoryQuery.GetSimpleCategories();
            LastArticles = _query.GetLastArticles();

            return Page();
        }
    }
}