namespace BlogManagement.Configuration.Permission
{
    public static class BlogPermissions
    {
        #region Article 

        public const string Article = "permission.blogArticle";
        public const string SearchArticle = "permission.blogArticle.search";
        public const string CreateArticle = "permission.blogArticle.create";
        public const string EditArticle = "permission.blogArticle.edit";

        #endregion

        #region blogArticle Category

        public const string ArticleCategory = "permission.blogArticleCategory";
        public const string SearchArticleCategory = "permission.blogArticleCategory.search";
        public const string CreateArticleCategory = "permission.blogArticleCategory.create";
        public const string EditArticleCategory = "permission.blogArticleCategory.edit";

        #endregion

    }
}