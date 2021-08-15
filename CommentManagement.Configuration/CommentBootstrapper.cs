using CommentManagement.Application;
using CommentManagement.Application.Contract.ArticleComment;
using CommentManagement.Application.Contract.ProductComment;
using CommentManagement.Domain.ArticleCommentAgg;
using CommentManagement.Domain.ProductCommentAgg;
using CommentManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Configuration
{
    public static class CommentBootstrapper 
    {
        public static void AddCommentConfigure(this IServiceCollection services ,string connection)
        {
            services.AddDbContext<CommentContext>(options =>
            {
                options.UseSqlServer(connection);
            });


            #region Product Comment

            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<IProductCommentApplication, ProductCommentApplication>();

            #endregion

            #region Article Comment

            services.AddScoped<IArticleCommentRepository, ArticleCommentRepository>();
            services.AddScoped<IArticleCommentApplication, ArticleCommentApplication>();

            #endregion
        }
    }
}
