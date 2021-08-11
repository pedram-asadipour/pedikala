using System.Collections.Generic;
using _01_Framework.Application;
using _01_Framework.Tools;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _repository;
        private readonly IFileManager _fileManager;
        private readonly IArticleCategoryRepository _categoryRepository;

        public ArticleApplication(IArticleRepository repository, IFileManager fileManager,
            IArticleCategoryRepository categoryRepository)
        {
            _repository = repository;
            _fileManager = fileManager;
            _categoryRepository = categoryRepository;
        }

        public List<ArticleViewModel> GetAll(ArticleSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditArticle GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateArticle command)
        {
            var operationResult = new OperationResult();

            var category = _categoryRepository.GetCategoryBy(command.CategoryId);

            if (_repository.Exists(x => x.Title == command.Title))
                return operationResult.Failed(ApplicationMessages.Exists);

            var imageFile = _fileManager.Uploader(command.Image, $"مقالات/{category.Name}/{command.Title}");

            var article = new Article(command.Title, imageFile, command.ImageAlt, command.ImageTitle,
                command.ShortDescription, command.Description, command.Keyword, command.MetaDescription,
                command.PublishDate.ToGregorianDate(), command.CanonicalAddress
                , command.CategoryId);

            _repository.Create(article);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operationResult = new OperationResult();

            var article = _repository.GetBy(command.Id);

            var category = _categoryRepository.GetCategoryBy(command.CategoryId);

            if (article == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            var imageFile = _fileManager.Uploader(command.Image, $"مقالات/{category.Name}/{command.Title}");

            if (command.Image != null)
                _fileManager.Remove(article.Image);

            article.Edit(command.Title, imageFile, command.ImageAlt, command.ImageTitle,
                command.ShortDescription, command.Description, command.Keyword, command.MetaDescription,
                command.PublishDate.ToGregorianDate(), command.CanonicalAddress
                , command.CategoryId);

            _repository.Edit(article);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}