using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IFileManager _fileManager;

        public ProductPictureApplication(IProductPictureRepository repository, IFileManager fileManager,
            IProductRepository productRepository)
        {
            _repository = repository;
            _fileManager = fileManager;
            _productRepository = productRepository;
        }

        public List<ProductPictureViewModel> GetAll(ProductPictureSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditProductPicture GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operationResult = new OperationResult();
            var productName = _productRepository.GetNameBy(command.ProductId);
            var categoryName = _productRepository.GetCategoryNameBy(command.ProductId);

            var imageFile = _fileManager.Uploader(command.Image, $"{categoryName}/{productName}");

            var productPicture =
                new ProductPicture(command.ProductId, imageFile, command.ImageAlt, command.ImageTitle);

            _repository.Create(productPicture);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operationResult = new OperationResult();
            var productName = _productRepository.GetNameBy(command.ProductId);
            var categoryName = _productRepository.GetCategoryNameBy(command.ProductId);
            var productPicture = _repository.GetBy(command.Id);

            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            var categoryModel = _productRepository.GetCategoryNameBy(command.ProductId);

            var imageFile = _fileManager.Uploader(command.Image, $"{categoryName}/{productName}");

            if (command.Image != null)
                _fileManager.Remove(productPicture.Image);

            productPicture.Edit(command.ProductId, imageFile, command.ImageAlt, command.ImageTitle);

            _repository.Edit(productPicture);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var productPicture = _repository.GetBy(id);

            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            productPicture.Removed();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();

            var productPicture = _repository.GetBy(id);

            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            productPicture.Restore();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}