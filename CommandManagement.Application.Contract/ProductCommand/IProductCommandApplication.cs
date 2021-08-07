using System.Collections.Generic;
using _01_Framework.Application;

namespace CommandManagement.Application.Contract.ProductCommand
{
    public interface IProductCommandApplication
    {
        List<ProductCommandViewModel> GetAll(ProductCommandSearchModel search);
        OperationResult Create(CreateProductCommand command);
        OperationResult Confirmed(long id);
        OperationResult Canceled(long id);
        int GetCountCommand();
    }
}