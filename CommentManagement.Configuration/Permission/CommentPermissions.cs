namespace CommentManagement.Configuration.Permission
{
    public static class CommentPermissions
    {
        #region Product Comment

        public const string ProductComment = "permission.productComment";
        public const string SearchProductComment = "permission.productComment.search";
        public const string ConfirmCancelProductComment = "permission.productComment.confirm_cancel";

        #endregion

        #region Article Comment

        public const string ArticleComment = "permission.articleComment";
        public const string SearchArticleComment = "permission.articleComment.search";
        public const string ConfirmCancelArticleComment = "permission.articleComment.confirm_cancel";

        #endregion
    }
}