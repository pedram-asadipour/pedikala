using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace CommentManagement.Configuration.Permission
{
    public class CommentPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Product Comment(کامنت محصولات)", new List<PermissionDto>()
                    {
                        new PermissionDto(CommentPermissions.ProductComment, "مدیریت کامنت محصولات"),
                        new PermissionDto(CommentPermissions.SearchProductComment, "جست و جو در کامنت محصولات"),
                        new PermissionDto(CommentPermissions.ConfirmCancelProductComment, "تایید و عدم تایید کامنت محصولات")
                    }
                },
                {
                    "Article Comment(کامنت مقالات)", new List<PermissionDto>()
                    {
                        new PermissionDto(CommentPermissions.ArticleComment, "مدیریت کامنت مقالات"),
                        new PermissionDto(CommentPermissions.SearchArticleComment, "جست و جو در کامنت مقالات"),
                        new PermissionDto(CommentPermissions.ConfirmCancelArticleComment, "تایید و عدم تایید کامنت مقالات")
                    }
                }
            };
        }
    }
}