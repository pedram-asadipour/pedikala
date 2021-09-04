using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permission
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Product(محصولات)", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.Product,"مدیریت محصولات"),
                        new PermissionDto(ShopPermissions.SearchProduct,"جست و جو در محصولات"),
                        new PermissionDto(ShopPermissions.CreateProduct,"ایحاد محصول"),
                        new PermissionDto(ShopPermissions.EditProduct,"ویرایش محصول"),
                        new PermissionDto(ShopPermissions.RemoveRestoreProduct,"حذف و بازیابی محصول"),
                    }
                },
                {
                    "Product Category(دسته بندی محصولات)", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.ProductCategory,"مدیریت دسته بندی محصولات"),
                        new PermissionDto(ShopPermissions.SearchProductCategory,"جست و جو در دسته بندی محصولات"),
                        new PermissionDto(ShopPermissions.CreateProductCategory,"ایحاد دسته بندی محصول"),
                        new PermissionDto(ShopPermissions.EditProductCategory,"ویرایش دسته بندی محصول")
                    }
                },
                {
                    "Product Picture(تصاویر محصولات)", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.ProductPicture,"مدیریت تصاویر محصولات"),
                        new PermissionDto(ShopPermissions.SearchProductPicture,"جست و جو در تصاویر محصولات"),
                        new PermissionDto(ShopPermissions.CreateProductPicture,"ایحاد تصویر محصول"),
                        new PermissionDto(ShopPermissions.EditProductPicture,"ویرایش تصویر محصول"),
                        new PermissionDto(ShopPermissions.RemoveRestoreProductPicture,"حذف و بازیابی تصویر محصول"),
                    }
                },
                {
                    "Order (فاکتور سفارشات)", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.Orders,"مدیریت فاکتور سفارشات"),
                        new PermissionDto(ShopPermissions.SearchOrders,"جست و جو در فاکتور سفارشات"),
                        new PermissionDto(ShopPermissions.OrderProcess,"پردازش سفارش"),
                        new PermissionDto(ShopPermissions.OrderItems,"ریز فاکتور سفارشات")
                    }
                },
            };
        }
    }
}