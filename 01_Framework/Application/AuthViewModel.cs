namespace _01_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; private set; }
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public long RoleId { get; private set; }
        public string Role { get; private set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, string fullname, string username, long roleId, string role)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            RoleId = roleId;
            Role = role;
        }
    }
}