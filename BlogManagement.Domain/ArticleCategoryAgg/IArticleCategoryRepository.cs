﻿using System.Collections.Generic;
using _01_Framework.Domain;
using BlogManagement.Application.Contract.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IGenericRepository<ArticleCategory,long>
    {
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
        EditArticleCategory GetDetail(long id);
    }
}