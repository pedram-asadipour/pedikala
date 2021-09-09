using System;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;
using _01_PedikalaQuery.Contract.Article;
using _01_PedikalaQuery.Contract.ArticleComment;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_PedikalaQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleBy(long articleId)
        {

            var commentsQuery = _commentContext.ArticleComments
                .Where(x => x.ArticleId == articleId && x.IsConfirmed && !x.IsCanceled)
                .Select(x => new ArticleCommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToPersianDate(),
                    ParentId = x.ParentId
                })
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .ToList();

            var articleQuery = _context.Articles
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
                    CategoryName = x.Category.Name,
                    Comments = commentsQuery
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == articleId);

            return articleQuery;
        }

        public List<ArticleMiniWrapQueryModel> GetLastArticlesMini()
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
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public List<ArticleWrapQueryModel> GetLastArticles()
        {
            return _context.Articles
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleWrapQueryModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    ShortDescription = x.ShortDescription,
                    PublishDate = x.PublishDate.ToPersianDate()
                })
                .Take(8)
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList();
        }
    }
}