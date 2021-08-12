using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Article
{
    public interface IArticleQuery
    {
        List<ArticleMiniWrapQueryModel> GetLastArticles();
    }
}