﻿        namespace AccountManagement.Application.Contract.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string ProfileImage { get; set; }
        public string CreationDate { get; set; }
    }
}