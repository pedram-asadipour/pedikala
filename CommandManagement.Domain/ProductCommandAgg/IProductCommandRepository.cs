using System.Collections.Generic;
using _01_Framework.Domain;
using CommandManagement.Application.Contract.ProductCommand;

namespace CommandManagement.Domain.ProductCommandAgg
{
    public interface IProductCommandRepository : IGenericRepository<ProductCommand,long>
    {
        List<ProductCommandViewModel> GetAll(ProductCommandSearchModel search);
        int GetCountCommand();
    }
}