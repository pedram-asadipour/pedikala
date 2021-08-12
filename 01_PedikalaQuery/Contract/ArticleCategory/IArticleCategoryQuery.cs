using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryMenuQueryModel> GetCategories();
        ArticleCategoryQueryModel GetCategoryBy(long id);
        List<SimpleArticleCategoryQueryModel> GetSimpleCategories();
    }
}