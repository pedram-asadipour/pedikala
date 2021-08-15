using System.Collections.Generic;
using _01_Framework.Domain;
using CommentManagement.Application.Contract.ArticleComment;

namespace CommentManagement.Domain.ArticleCommentAgg
{
    public interface IArticleCommentRepository : IGenericRepository<ArticleComment,long>
    {
        List<ArticleCommentViewModel> GetAll(ArticleCommentSearchModel search);
        int GetCountComments();
    }
}