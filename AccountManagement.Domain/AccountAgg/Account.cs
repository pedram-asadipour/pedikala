using _01_Framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string ProfileImage { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; set; }

        protected Account()
        {
        }

        public Account(string fullname, string username, string password, string mobile, long roleId, string profileImage)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            ProfileImage = profileImage;
        }

        public void Edit(string fullname, string username, string mobile, long roleId, string profileImage)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profileImage))
                ProfileImage = profileImage;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}