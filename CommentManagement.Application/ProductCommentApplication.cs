using System.Collections.Generic;
using _01_Framework.Application;
using CommentManagement.Application.Contract.ProductComment;
using CommentManagement.Domain.ArticleCommentAgg;
using CommentManagement.Domain.ProductCommentAgg;

namespace CommentManagement.Application
{
    public class ProductCommentApplication : IProductCommentApplication
    {
        private readonly IProductCommentRepository _repository;

        public ProductCommentApplication(IProductCommentRepository repository)
        {
            _repository = repository;
        }

        public List<ProductCommentViewModel> GetAll(ProductCommentSearchModel search)
        {
            return _repository.GetAll(search);
        }

        public OperationResult Create(CreateProductComment comment)
        {
            var operationResult = new OperationResult();

            var productCommand = new ProductComment(comment.ProductId, comment.Name, comment.Email, comment.Message);

            _repository.Create(productCommand);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Confirmed(long id)
        {
            var operationResult = new OperationResult();

            var productCommand = _repository.GetBy(id);

            if (productCommand == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            productCommand.IsConfirm();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Canceled(long id)
        {
            var operationResult = new OperationResult();

            var productCommand = _repository.GetBy(id);

            if (productCommand == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            productCommand.IsCancel();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public int GetCountComments()
        {
            return _repository.GetCountCommand();
        }
    }
}