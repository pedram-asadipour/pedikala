using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IFileManager _fileManager;

        public ProductCategoryApplication(IProductCategoryRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
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

            var imageFile = _fileManager.Uploader(command.Image, $"{command.Name}");

            var productCategory = new ProductCategory(command.Name, command.Description,imageFile,command.ImageAlt,command.ImageTitle,
            command.Keyword,command.MetaDescription);

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

            var imageFile = _fileManager.Uploader(command.Image, $"{command.Name}");

            if(command.Image != null)
                _fileManager.Remove(productCategory.Image);

            productCategory.Edit(command.Name, command.Description,
                imageFile, command.ImageAlt, command.ImageTitle, command.Keyword, command.MetaDescription);

            _repository.Edit(productCategory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}