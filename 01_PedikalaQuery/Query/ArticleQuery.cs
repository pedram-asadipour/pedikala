using System;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Article;
using BlogManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
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
                .ToList();
        }
    }
}