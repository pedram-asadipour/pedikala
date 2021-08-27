using _01_Framework.Domain;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; set; }
        public List<RolePermission> Permissions { get; set; }

        protected Role()
        {
            Accounts = new List<Account>();
            Permissions = new List<RolePermission>();
        }

        public Role(string name, List<RolePermission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }

        public void Edit(string name,List<RolePermission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}
