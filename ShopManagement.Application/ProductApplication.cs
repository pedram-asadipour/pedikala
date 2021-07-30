using _01_Framework.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repository;

        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }


        public List<ProductViewModel> GetAll(ProductSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public List<SelectModel> GetAllSelectModel()
        {
            return _repository.GetAllSelectModels();
        }

        public EditProduct GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateProduct command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Exists);

            if (_repository.Exists(x => x.ProductCode == command.ProductCode))
                return operationResult.Failed(ApplicationMessages.DuplicationCode);

            var product = new Product(command.Name, command.ProductCode.ToLower(), command.ShortDescription,
                command.Description, command.Image, command.ImageAlt, command.ImageTitle,
                command.Keyword, command.MetaDescription, command.CategoryId);

            _repository.Create(product);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operationResult = new OperationResult();
            var product = _repository.GetBy(command.Id);

            if (product == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            if (_repository.Exists(x => x.ProductCode == command.ProductCode && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicationCode);

            product.Edit(command.Name, command.ProductCode.ToLower(), command.ShortDescription,
                command.Description, command.Image, command.ImageAlt, command.ImageTitle,
                command.Keyword, command.MetaDescription, command.CategoryId);

            _repository.Edit(product);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();
            var product = _repository.GetBy(id);

            if (product == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            product.Removed();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var product = _repository.GetBy(id);

            if (product == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            product.Restore();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}