namespace _01_Framework.Infrastructure
{
    public class PermissionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }

        public PermissionDto(string permission, string name)
        {
            Permission = permission;
            Name = name;
        }
    }
}