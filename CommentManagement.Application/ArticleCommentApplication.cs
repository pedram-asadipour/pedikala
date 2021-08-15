using System.Collections.Generic;
using _01_Framework.Application;
using CommentManagement.Application.Contract.ArticleComment;
using CommentManagement.Domain.ArticleCommentAgg;

namespace CommentManagement.Application
{
    public class ArticleCommentApplication : IArticleCommentApplication
    {
        private readonly IArticleCommentRepository _repository;

        public ArticleCommentApplication(IArticleCommentRepository repository)
        {
            _repository = repository;
        }

        public List<ArticleCommentViewModel> GetAll(ArticleCommentSearchModel search)
        {
            return _repository.GetAll(search);
        }

        public OperationResult Create(CreateArticleComment comment)
        {
            var operationResult = new OperationResult();

            var articleComment = new ArticleComment(comment.ArticleId, comment.Name, comment.Email, comment.Message,
                comment.WebSite, comment.ParentId);

            _repository.Create(articleComment);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Confirmed(long id)
        {
            var operationResult = new OperationResult();

            var articleComment = _repository.GetBy(id);

            if (articleComment == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            articleComment.IsConfirm();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Canceled(long id)
        {
            var operationResult = new OperationResult();

            var articleComment = _repository.GetBy(id);

            if (articleComment == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            articleComment.IsCancel();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public int GetCountComments()
        {
            return _repository.GetCountComments();
        }
    }
}