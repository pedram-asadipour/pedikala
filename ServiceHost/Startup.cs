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

            services.AddQueryConfigure();
            services.AddSingleton<IFileManager, FileManager>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic)
            );

            services.AddHttpContextAccessor();
            services.AddSingleton<IAuthHelper, AuthHelper>();

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
                    options.AccessDeniedPath = new PathString("/AccessDenied");
                });

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