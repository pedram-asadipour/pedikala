using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace SiteManagement.Configuration.Permission
{
    public class SitePermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "ContactUs(تنظیمات ارتباط با ما)", new List<PermissionDto>()
                    {
                        new PermissionDto(SitePermissions.Messages,"پیغام ها"),
                        new PermissionDto(SitePermissions.Status,"وضعیت"),
                        new PermissionDto(SitePermissions.EditInfo,"ویرایش اطلاعات ارتباط با ما")
                    }
                }
            };
        }
    }
}