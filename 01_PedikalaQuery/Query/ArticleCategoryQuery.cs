using System;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Article;
using _01_PedikalaQuery.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_PedikalaQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _context;

        public ArticleCategoryQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryMenuQueryModel> GetCategories()
        {
            return _context.ArticleCategories
                .Select(x => new ArticleCategoryMenuQueryModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public ArticleCategoryQueryModel GetCategoryBy(long id)
        {
            return _context.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    Articles = ArticlesMapping(x.Articles)
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<SimpleArticleCategoryQueryModel> GetSimpleCategories()
        {
            return _context.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new SimpleArticleCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ArticleCount = x.Articles.Count(x => x.PublishDate <= DateTime.Now)
                })
                .ToList();
        }

        private static List<ArticleWrapQueryModel> ArticlesMapping(IEnumerable<Article> articles)
        {
            return articles
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleWrapQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    ShortDescription = x.ShortDescription,
                    PublishDate = x.PublishDate.ToPersianDate()
                })
                .ToList();
        }
    }
}