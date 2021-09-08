using System;

namespace _01_Framework.Application
{
    public class UserAuthenticationAttribute : Attribute
    {
        public string PageRedirect { get; set; }

        public UserAuthenticationAttribute(string pageRedirect)
        {
            PageRedirect = pageRedirect;
        }
    }
}