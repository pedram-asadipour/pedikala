using System;
using System.Collections.Generic;
using _01_Framework.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;
        private readonly IFileManager _fileManager;

        public ArticleCategoryApplication(IArticleCategoryRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }

        public List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditArticleCategory GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Exists);

            var imageFile = _fileManager.Uploader(command.Image, $"مقالات/{command.Name}");

            var articleCategory = new ArticleCategory(command.Name, command.Description,imageFile, command.ImageAlt, command.ImageTitle,
                command.Keyword, command.MetaDescription);

            _repository.Create(articleCategory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operationResult = new OperationResult();

            var articleCategory = _repository.GetBy(command.Id);

            if (articleCategory == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);


            var imageFile = _fileManager.Uploader(command.Image, $"مقالات/{command.Name}");

            if(command.Image != null)
                _fileManager.Remove(articleCategory.Image);

            articleCategory.Edit(command.Name, command.Description, imageFile, command.ImageAlt, command.ImageTitle,
                command.Keyword, command.MetaDescription);

            _repository.Edit(articleCategory);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}
