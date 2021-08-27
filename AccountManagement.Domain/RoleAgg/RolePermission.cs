namespace AccountManagement.Domain.RoleAgg
{
    public class RolePermission
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Permission { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        public RolePermission(string permission)
        {
            Permission = permission;
        }
    }
}