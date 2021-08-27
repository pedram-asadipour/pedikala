namespace DiscountManagement.Configuration.Permission
{
    public static class DiscountPermissions
    {
        #region Customer Discount

        public const string CustomerDiscount = "permission.customerDicount";
        public const string SearchCustomerDiscount = "permission.customerDicount.search";
        public const string DefineCustomerDiscount = "permission.customerDicount.define";
        public const string EditCustomerDiscount = "permission.customerDicount.edit";
        public const string RemoveRestoreCustomerDiscount = "permission.customerDicount.remove_restore";

        #endregion

        #region Colleague Discount

        public const string ColleagueDiscount = "permission.colleagueDiscount";
        public const string SearchColleagueDiscount = "permission.colleagueDiscount.search";
        public const string DefineColleagueDiscount = "permission.colleagueDiscount.define";
        public const string EditColleagueDiscount = "permission.colleagueDiscount.edit";
        public const string RemoveRestoreColleagueDiscount = "permission.customerDicount.remove_restore";

        #endregion
    }
}