using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : GenericRepository<ArticleCategory,long> ,IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    ArticleCount = x.Articles.Count,
                    CreationDate = x.CreationDate.ToPersianDate()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            query = query.AsNoTracking();

            return query.ToList();
        }

        public EditArticleCategory GetDetail(long id)
        {
            return _context.ArticleCategories
                .Select(x => new EditArticleCategory
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Keyword = x.Keyword,
                    MetaDescription = x.MetaDescription,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<SelectModel> GetAllSelectModel()
        {
            return _context.ArticleCategories
                .Select(x => new SelectModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public ArticleCategoryWithModel GetCategoryBy(long id)
        {
            return _context.ArticleCategories
                .Select(x => new ArticleCategoryWithModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}