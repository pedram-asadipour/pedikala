using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace AccountManagement.Configuration.Permission
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Account(کاربران)", new List<PermissionDto>()
                    {
                        new PermissionDto(AccountPermissions.Account, "مدیریت کاربران"),
                        new PermissionDto(AccountPermissions.SearchAccount, "جست و جو در کاربران"),
                        new PermissionDto(AccountPermissions.RegisterAccount, "ایحاد کاربر"),
                        new PermissionDto(AccountPermissions.EditAccount, "ویرایش کاربر"),
                        new PermissionDto(AccountPermissions.ChangePasswordAccount, "ویرایش رمز عبور کاربر")
                    }
                },
                {
                    "Role(دسترسی ها)", new List<PermissionDto>()
                    {
                        new PermissionDto(AccountPermissions.Role, "مدیریت دسترسی ها"),
                        new PermissionDto(AccountPermissions.CreateRole, "ایحاد دسترسی"),
                        new PermissionDto(AccountPermissions.EditRole, "ویرایش دسترسی"),
                    }
                }
            };
        }
    }
}