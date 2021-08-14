using System;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_PedikalaQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
        }

        public ArticleQueryModel GetArticleBy(long id)
        {
            return _context.Articles
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Description = x.Description,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                    PublishDate = x.PublishDate.ToPersianDate(),
                    CanonicalAddress = x.CanonicalAddress,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleMiniWrapQueryModel> GetLastArticles()
        {
            return _context.Articles
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleMiniWrapQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    PublishDate = x.PublishDate.ToPersianDate()
                })
                .Take(5)
                .AsNoTracking()
                .ToList();
        }
    }
}