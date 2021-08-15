using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Application.Contract.ArticleComment;
using CommentManagement.Application.Contract.ProductComment;
using CommentManagement.Domain.ArticleCommentAgg;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCommentRepository : GenericRepository<ArticleComment,long> ,IArticleCommentRepository
    {
        private readonly CommentContext _context;
        private readonly BlogContext _blogContext;
        public ArticleCommentRepository(CommentContext context, BlogContext blogContext) : base(context)
        {
            _context = context;
            _blogContext = blogContext;
        }

        public List<ArticleCommentViewModel> GetAll(ArticleCommentSearchModel search)
        {
            var articleQuery = _blogContext.Articles
                .Select(x => new { x.Id, x.Title })
                .AsNoTracking()
                .ToList();

            var query = _context.ArticleComments
                .Select(x => new ArticleCommentViewModel
                {
                    Id = x.Id,
                    ArticleId = x.ArticleId,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    WebSite = x.WebSite,
                    CreationDate = x.CreationDate.ToPersianDate(),
                    IsConfirmed = x.IsConfirmed,
                    IsCanceled = x.IsCanceled
                });

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));

            if (!string.IsNullOrWhiteSpace(search.Email))
                query = query.Where(x => x.Email.Contains(search.Email));

            query = query.OrderByDescending(x => x.Id);
            query = query.AsNoTracking();

            var queryViewModel = query.ToList();

            queryViewModel.ForEach(x =>
                x.ArticleName = articleQuery.FirstOrDefault(article => article.Id == x.ArticleId)?.Title);

            return queryViewModel.ToList();
        }

        public int GetCountComments()
        {
            return _context.ArticleComments.Count(x => !x.IsConfirmed && !x.IsCanceled);
        }
    }
}