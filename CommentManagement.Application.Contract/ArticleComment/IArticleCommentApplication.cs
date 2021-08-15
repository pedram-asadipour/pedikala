using System.Collections.Generic;
using _01_Framework.Application;

namespace CommentManagement.Application.Contract.ArticleComment
{
    public interface IArticleCommentApplication
    {
        List<ArticleCommentViewModel> GetAll(ArticleCommentSearchModel search);
        OperationResult Create(CreateArticleComment comment);
        OperationResult Confirmed(long id);
        OperationResult Canceled(long id);
        int GetCountComments();
    }
}