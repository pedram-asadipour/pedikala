using System.Collections.Generic;
using _01_Framework.Application;
using CommandManagement.Application.Contract.ProductCommand;
using CommandManagement.Domain.ProductCommandAgg;

namespace CommandManagement.Application
{
    public class ProductCommandApplication : IProductCommandApplication
    {
        private readonly IProductCommandRepository _repository;

        public ProductCommandApplication(IProductCommandRepository repository)
        {
            _repository = repository;
        }

        public List<ProductCommandViewModel> GetAll(ProductCommandSearchModel search)
        {
            return _repository.GetAll(search);
        }

        public OperationResult Create(CreateProductCommand command)
        {
            var operationResult = new OperationResult();

            var productCommand = new ProductCommand(command.ProductId, command.Name, command.Email, command.Message);

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

        public int GetCountCommand()
        {
            return _repository.GetCountCommand();
        }
    }
}