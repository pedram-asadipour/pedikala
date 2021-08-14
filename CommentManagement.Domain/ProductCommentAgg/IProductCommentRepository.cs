using System.Collections.Generic;
using _01_Framework.Domain;
using CommentManagement.Application.Contract.ProductComment;

namespace CommentManagement.Domain.ProductCommentAgg
{
    public interface IProductCommentRepository : IGenericRepository<ProductComment,long>
    {
        List<ProductCommentViewModel> GetAll(ProductCommentSearchModel search);
        int GetCountCommand();
    }
}