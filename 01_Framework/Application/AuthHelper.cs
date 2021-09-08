using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _01_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Login(AuthViewModel account)
        {
            var permissions = JsonConvert.SerializeObject(account.Permissions);

            var claims = new List<Claim>()
            {
                new Claim("AccountId",account.AccountId.ToString()),
                new Claim(ClaimTypes.Name,account.Fullname),
                new Claim("Username",account.Username),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim("RoleName",account.RoleName),
                new Claim(ClaimTypes.MobilePhone,account.Mobile),
                new Claim("Profile" , account.Profile),
                new Claim( "CreationDate" , account.CreationDate),
                new Claim("Permissions",permissions)
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(5)
            };

            _contextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity is {IsAuthenticated: true};
        }

        public AuthViewModel GetCurrentAccount()
        {
            if (!IsAuthenticated())
                return new AuthViewModel();

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();

            var accountId = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId")?.Value);
            var fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var username = claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            var roleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            var roleName = claims.FirstOrDefault(x => x.Type == "RoleName")?.Value;
            var mobile = claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value;
            var profile = claims.FirstOrDefault(x => x.Type == "Profile")?.Value;
            var creationDate = claims.FirstOrDefault(x => x.Type == "CreationDate")?.Value;
            var permissions = JsonConvert.DeserializeObject<List<string>>(claims.FirstOrDefault(x => x.Type == "Permissions")?.Value);

            var result = new AuthViewModel(accountId, fullname,username,roleId,roleName,mobile,profile,creationDate,permissions);

            return result;
        }
    }
}