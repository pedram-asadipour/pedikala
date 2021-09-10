using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace Banner.Management.Configuration.Permission
{
    public class BannerPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Slider (سلایدر)", new List<PermissionDto>()
                    {
                        new PermissionDto(BannerPermissions.Slider, "مدیریت سلایدر ها"),
                        new PermissionDto(BannerPermissions.CreateSlider, "ایحاد سلایدر"),
                        new PermissionDto(BannerPermissions.EditSlider, "ویرایش سلایدر"),
                        new PermissionDto(BannerPermissions.RemoveRestoreSlider, "حذف و بازیابی اسلایدر"),
                    }
                }
            };
        }
    }
}