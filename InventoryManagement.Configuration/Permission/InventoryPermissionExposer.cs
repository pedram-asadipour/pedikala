using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace InventoryManagement.Configuration.Permission
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Inventory(انبار ها)", new List<PermissionDto>()
                    {
                        new PermissionDto(InventoryPermissions.Inventory,"مدیریت انبار"),
                        new PermissionDto(InventoryPermissions.ListOperationLog,"ریز گردش انبار"),
                        new PermissionDto(InventoryPermissions.SearchInventory,"جست و جو در انبار ها"),
                        new PermissionDto(InventoryPermissions.CreateInventory,"ایجاد انبار"),
                        new PermissionDto(InventoryPermissions.EditInventory,"ویرایش انبار"),
                        new PermissionDto(InventoryPermissions.IncreaseInventory,"افزایش موجودی انبار"),
                        new PermissionDto(InventoryPermissions.ReduceInventory,"کاهش موجودی انبار")
                    }
                }
            };
        }
    }
}