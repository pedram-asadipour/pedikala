using System.Collections.Generic;
using _01_Framework.Domain;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IGenericRepository<Article,long>
    {
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);
        EditArticle GetDetail(long id);
    }
}