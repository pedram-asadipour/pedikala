using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_PedikalaQuery.Contract.Article;
using _01_PedikalaQuery.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article { get; set; }
        public List<SimpleArticleCategoryQueryModel> SimpleCategories { get; set; }
        public List<ArticleMiniWrapQueryModel> LastArticles { get; set; }

        private readonly IArticleQuery _query;
        private readonly IArticleCategoryQuery _categoryQuery;

        public ArticleModel(IArticleQuery query, IArticleCategoryQuery categoryQuery)
        {
            _query = query;
            _categoryQuery = categoryQuery;
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
    }
}
