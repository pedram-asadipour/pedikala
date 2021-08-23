using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _01_Framework.Application;
using _01_PedikalaQuery.Configuration;
using AccountManagement.Configuration;
using BlogManagement.Configuration;
using CommentManagement.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceHost.Framework;
using ShopManagement.Configuration;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("connection");

            services.AddShopConfigure(connection);
            services.AddDiscountConfigure(connection);
            services.AddInventoryConfigure(connection);
            services.AddCommentConfigure(connection);
            services.AddBlogConfigure(connection);
            services.AddAccountConfigure(connection);

            services.AddSingleton<IFileManager, FileManager>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthHelper, AuthHelper>();
            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic)
            );

            services.AddHttpContextAccessor();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account");
                    options.LogoutPath = new PathString("/Account");
                    options.AccessDeniedPath = new PathString("/404");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString(),
                    AccountRoles.ContentManager.ToString(),
                    AccountRoles.Accountants.ToString()
                }));

                options.AddPolicy("ShopManagement",builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString(),
                    AccountRoles.Accountants.ToString()
                }));

                options.AddPolicy("InventoryManagement", builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString(),
                    AccountRoles.Accountants.ToString()
                }));

                options.AddPolicy("DiscountManagement", builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString(),
                    AccountRoles.Accountants.ToString()
                }));

                options.AddPolicy("BlogManagement", builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString(),
                    AccountRoles.ContentManager.ToString()
                }));

                options.AddPolicy("CommentManagement", builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString(),
                    AccountRoles.ContentManager.ToString()
                }));

                options.AddPolicy("AccountManagement", builder => builder.RequireRole(new List<string>()
                {
                    AccountRoles.Administrator.ToString()
                }));
            });

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Shop", "ShopManagement");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Inventory", "InventoryManagement");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Discount", "DiscountManagement");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Blog", "BlogManagement");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Comment", "CommentManagement");
                options.Conventions.AuthorizeAreaFolder("Admin", "/Accounts", "AccountManagement");
            });

            services.AddQueryConfigure();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}