using System.Collections.Generic;
using _01_Framework.Application;
using BlogManagement.Application.Contract.ArticleCategory;

namespace BlogManagement.Application.Contract.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);
        EditArticle GetDetail(long id);
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
    }
}