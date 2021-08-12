using System;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : GenericRepository<Article, long>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetAll(ArticleSearchModel searchModel)
        {
            var query = _context.Articles
                .Include(x => x.Category)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    PublishDate = x.PublishDate.ToPersianDate(),
                    CreationDate = x.CreationDate.ToPersianDate(),
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Status = x.PublishDate <= DateTime.Now
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            query = query.AsNoTracking();

            return query.ToList();
        }

        public EditArticle GetDetail(long id)
        {
            return _context.Articles
                .Select(x => new EditArticle
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    PublishDate = x.PublishDate.ToString("yyyy/MM/dd"),
                    CanonicalAddress = x.CanonicalAddress,
                    CategoryId = x.CategoryId
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}