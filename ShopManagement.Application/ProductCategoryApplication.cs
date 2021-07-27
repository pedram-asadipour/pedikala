using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryApplication(IProductCategoryRepository repository)
        {
            _repository = repository;
        }


        public List<ProductCategoryViewModel> GetAll(ProductCategorySearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public List<SelectModel> GetAllSelectModel()
        {
            return _repository.GetAllSelectModel();
        }

        public EditProductCategory GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Exists);

            var productCategory = new ProductCategory(command.Name, command.Description,
                command.Image, command.ImageAlt, command.ImageTitle, command.Keyword, command.MetaDescription);

            _repository.Create(productCategory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory = _repository.GetBy(command.Id);

            if (productCategory == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplication);

            productCategory.Edit(command.Name, command.Description,
                command.Image, command.ImageAlt, command.ImageTitle, command.Keyword, command.MetaDescription);

            _repository.Edit(productCategory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}