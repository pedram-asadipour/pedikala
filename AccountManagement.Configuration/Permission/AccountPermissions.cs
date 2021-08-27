namespace AccountManagement.Configuration.Permission
{
    public class AccountPermissions
    {
        #region Account

        public const string Account = "permission.account";
        public const string SearchAccount = "permission.account.search";
        public const string RegisterAccount = "permission.account.register";
        public const string EditAccount = "permission.account.edit";
        public const string ChangePasswordAccount = "permission.account.changePassword";

        #endregion

        #region Role 

        public const string Role = "permission.role";
        public const string CreateRole = "permission.role.create";
        public const string EditRole = "permission.role.edit";

        #endregion
    }
}