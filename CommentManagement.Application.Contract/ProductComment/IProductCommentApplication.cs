using System.Collections.Generic;
using _01_Framework.Application;

namespace CommentManagement.Application.Contract.ProductComment
{
    public interface IProductCommentApplication
    {
        List<ProductCommentViewModel> GetAll(ProductCommentSearchModel search);
        OperationResult Create(CreateProductComment comment);
        OperationResult Confirmed(long id);
        OperationResult Canceled(long id);
        int GetCountCommand();
    }
}