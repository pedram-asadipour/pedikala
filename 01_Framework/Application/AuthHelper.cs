using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace _01_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _httpContext;

        public AuthHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void Login(AuthViewModel account)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id",account.Id.ToString()),
                new Claim(ClaimTypes.Name,account.Fullname),
                new Claim("Username",account.Username),
                new Claim(ClaimTypes.Role,account.RoleId.ToString()),
                new Claim("RoleName",account.RoleName),
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(5)
            };

            _httpContext.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);
        }

        public void SignOut()
        {
            _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsAuthenticated()
        {
            var claims = _httpContext.HttpContext.User.Claims.ToList();
            return claims.Count > 0;
        }

        public AuthViewModel GetCurrentAccount()
        {
            if (!IsAuthenticated())
                return new AuthViewModel();

            var claims = _httpContext.HttpContext.User.Claims.ToList();

            var result = new AuthViewModel
            (
                id:long.Parse(claims.FirstOrDefault(x => x.Type == "Id")?.Value),
                fullname:claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                username:claims.FirstOrDefault(x => x.Type == "Username")?.Value,
                roleId:long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value),
                roleName:claims.FirstOrDefault(x => x.Type == "RoleName")?.Value
            );

            return result;
        }
    }
}