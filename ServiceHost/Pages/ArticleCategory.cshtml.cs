using System.Collections.Generic;
using _01_PedikalaQuery.Contract.Article;
using _01_PedikalaQuery.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel Category { get; set; }
        public List<SimpleArticleCategoryQueryModel> SimpleCategories { get; set; }
        public List<ArticleMiniWrapQueryModel> LastArticles { get; set; }

        private readonly IArticleCategoryQuery _query;
        private readonly IArticleQuery _articleQuery;

        public ArticleCategoryModel(IArticleCategoryQuery query, IArticleQuery articleQuery)
        {
            _query = query;
            _articleQuery = articleQuery;
        }

        public IActionResult OnGet(long id,string slug)
        {
            if(id == 0)
                return NotFound();

            Category = _query.GetCategoryBy(id);

            if (Category == null)
                return NotFound();

            SimpleCategories = _query.GetSimpleCategories();
            LastArticles = _articleQuery.GetLastArticlesMini();

            return Page();
        }
    }
}
