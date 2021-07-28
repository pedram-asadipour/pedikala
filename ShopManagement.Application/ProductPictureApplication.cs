using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _repository;

        public ProductPictureApplication(IProductPictureRepository repository)
        {
            _repository = repository;
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

            if (_repository.Exists(x => x.ProductId == command.ProductId && x.Image == command.Image))
                return operationResult.Failed(ApplicationMessages.DuplicationImage);

            var productPicture =
                new ProductPicture(command.ProductId, command.Image, command.ImageAlt, command.ImageTitle);

            _repository.Create(productPicture);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operationResult = new OperationResult();

            var productPicture = _repository.GetBy(command.Id);

            if (productPicture == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x =>
                x.ProductId == command.ProductId && x.Image == command.Image && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicationImage);

            productPicture.Edit(command.ProductId, command.Image, command.ImageAlt, command.ImageTitle);

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