using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace BlogManagement.Configuration.Permission
{
    public class BlogPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Article(مقالات)", new List<PermissionDto>()
                    {
                        new PermissionDto(BlogPermissions.Article,"مدیریت مقالات"),
                        new PermissionDto(BlogPermissions.SearchArticle,"جست و جو در مقالات"),
                        new PermissionDto(BlogPermissions.CreateArticle,"ایحاد مقاله"),
                        new PermissionDto(BlogPermissions.EditArticle,"ویرایش مقاله"),
                    }
                },
                {
                    "Article Category(دسته بندی مقالات)", new List<PermissionDto>()
                    {
                        new PermissionDto(BlogPermissions.ArticleCategory,"مدیریت دسته بندی مقالات"),
                        new PermissionDto(BlogPermissions.SearchArticleCategory,"جست و جو در دسته بندی مقالات"),
                        new PermissionDto(BlogPermissions.CreateArticleCategory,"ایحاد دسته بندی مقاله"),
                        new PermissionDto(BlogPermissions.EditArticleCategory,"ویرایش دسته بندی مقاله")
                    }
                }
            };
        }
    }
}