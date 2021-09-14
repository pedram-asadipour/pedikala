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
                },
                {
                    "Footer (تنظیمات footer)", new List<PermissionDto>()
                    {
                        new PermissionDto(SitePermissions.EditFooter,"footer"),

                        new PermissionDto(SitePermissions.FooterLink,"لینک های footer"),
                        new PermissionDto(SitePermissions.CreateLink,"ایجاد لینک"),
                        new PermissionDto(SitePermissions.EditLink,"ویرایش لینک"),
                        new PermissionDto(SitePermissions.RemoveRestoreLink,"حذف و بازیابی لینک")
                    }
                }
            };
        }
    }
}