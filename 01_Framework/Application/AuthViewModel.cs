using System.Collections.Generic;

namespace _01_Framework.Application
{
    public class AuthViewModel
    {
        public long AccountId { get; private set; }
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public long RoleId { get; private set; }
        public string RoleName { get; private set; }
        public string Mobile { get; private set; }
        public string Profile { get; private set; }
        public string CreationDate { get; private set; }
        public List<string> Permissions { get; set; }

        public AuthViewModel()
        {
            Permissions = new List<string>();
        }

        public AuthViewModel(long accountId, string fullname, string username, long roleId, string roleName,
            string mobile, string profile, string creationDate, List<string> permissions)
        {
            AccountId = accountId;
            Fullname = fullname;
            Username = username;
            RoleId = roleId;
            RoleName = roleName;
            Mobile = mobile;

            Profile = string.IsNullOrWhiteSpace(profile) ? "default" : profile;

            CreationDate = creationDate;
            Permissions = permissions;
        }
    }
}