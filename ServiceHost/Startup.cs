using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
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
using Newtonsoft.Json;
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
            services.AddSingleton<IPermissionExposer, AdminPermissionExposer>();

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
                //Check Policy Admin With Permission (Admin)
                options.AddPolicy("Admin", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim =>
                        (claim.Type == "Permissions" &&
                         JsonConvert.DeserializeObject<List<string>>(claim.Value)
                             .Any(permission => permission == AdminPermission.Admin)
                        )
                    )
                ));
            });

            services.AddQueryConfigure();
            services.AddRazorPages()
                .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options => { options.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin"); });
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