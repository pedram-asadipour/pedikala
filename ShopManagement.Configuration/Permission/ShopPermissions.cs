namespace ShopManagement.Configuration.Permission
{
    public static class ShopPermissions
    {
        #region Product

        public const string Product = "permission.product";
        public const string SearchProduct = "permission.product.search";
        public const string CreateProduct = "permission.product.create";
        public const string EditProduct = "permission.product.edit";
        public const string RemoveRestoreProduct = "permission.product.remove_restore";

        #endregion

        #region Product Category

        public const string ProductCategory = "permission.productCategory";
        public const string SearchProductCategory = "permission.productCategory.search";
        public const string CreateProductCategory = "permission.productCategory.create";
        public const string EditProductCategory = "permission.productCategory.edit";

        #endregion

        #region Product Picture

        public const string ProductPicture = "permission.productPicture";
        public const string SearchProductPicture = "permission.productPicture.search";
        public const string CreateProductPicture = "permission.productPicture.create";
        public const string EditProductPicture = "permission.productPicture.edit";
        public const string RemoveRestoreProductPicture = "permission.productPicture.remove_restore";

        #endregion

        #region Order

        public const string Orders = "permission.orders";
        public const string SearchOrders = "permission.orders.search";
        public const string OrderProcess = "permission.orders.process";
        public const string OrderItems = "permission.orders.items";

        #endregion
    }
}