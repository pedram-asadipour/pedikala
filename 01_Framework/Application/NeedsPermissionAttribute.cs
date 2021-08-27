using System;

namespace _01_Framework.Application
{
    public class NeedsPermissionAttribute : Attribute
    {
        public string Permission { get; set; }

        public NeedsPermissionAttribute(string permission)
        {
            Permission = permission;
        }
    }
}