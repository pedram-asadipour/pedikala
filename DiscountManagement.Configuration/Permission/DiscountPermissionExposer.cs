using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace DiscountManagement.Configuration.Permission
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Customer Discount(تخفیفات مشتری)", new List<PermissionDto>()
                    {
                        new PermissionDto(DiscountPermissions.CustomerDiscount, "مدیریت تخفیفات مشتری"),
                        new PermissionDto(DiscountPermissions.SearchCustomerDiscount, "جست و جو در تخفیفات مشتری"),
                        new PermissionDto(DiscountPermissions.DefineCustomerDiscount, "ایجاد تخفیف مشتری"),
                        new PermissionDto(DiscountPermissions.EditCustomerDiscount, "ویرایش تخفیف مشتری"),
                        new PermissionDto(DiscountPermissions.RemoveRestoreCustomerDiscount, "حذف و بازیابی تخفیف مشتری")
                    }
                },
                {
                    "Colleague Discount(تخفیفات همکاران)", new List<PermissionDto>()
                    {
                        new PermissionDto(DiscountPermissions.ColleagueDiscount, "مدیریت تخفیفات همکاران"),
                        new PermissionDto(DiscountPermissions.SearchColleagueDiscount, "جست و جو در تخفیفات همکاران"),
                        new PermissionDto(DiscountPermissions.DefineColleagueDiscount, "ایجاد تخفیف همکاران"),
                        new PermissionDto(DiscountPermissions.EditColleagueDiscount, "ویرایش تخفیف همکاران"),
                        new PermissionDto(DiscountPermissions.RemoveRestoreColleagueDiscount, "حذف و بازیابی تخفیف همکاران")
                    }
                }
            };
        }
    }
}