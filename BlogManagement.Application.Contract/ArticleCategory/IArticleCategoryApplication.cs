using System.Collections.Generic;
using _01_Framework.Application;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
        EditArticleCategory GetDetail(long id);
        List<SelectModel> GetAllSelectModel();
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
    }
}