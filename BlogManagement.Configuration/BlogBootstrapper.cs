﻿using BlogManagement.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EFCore;
using BlogManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Configuration
{
    public static class BlogBootstrapper
    {
        public static void AddBlogConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            #region Article Category

            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<IArticleCategoryApplication, ArticleCategoryApplication>();

            #endregion
        }
    }
}
