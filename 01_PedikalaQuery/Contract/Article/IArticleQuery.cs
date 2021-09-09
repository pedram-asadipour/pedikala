using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Article
{
    public interface IArticleQuery
    {
        ArticleQueryModel GetArticleBy(long articleId);
        List<ArticleMiniWrapQueryModel> GetLastArticlesMini();
        List<ArticleWrapQueryModel> GetLastArticles();
    }
}