using System.Collections.Generic;
using _01_Framework.Infrastructure;

namespace ServiceHost.Framework
{
    public class AdminPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Admin", new List<PermissionDto>()
                    {
                        new PermissionDto(AdminPermission.Admin, "پنل مدیریت سایت")
                    }
                }
            };
        }
    }
}