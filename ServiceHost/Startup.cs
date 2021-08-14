using System.Text.Encodings.Web;
using System.Text.Unicode;
using _01_Framework.Application;
using _01_PedikalaQuery.Configuration;
using BlogManagement.Configuration;
using CommandManagement.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddCommandConfigure(connection);
            services.AddBlogConfigure(connection);

            services.AddQueryConfigure();
            services.AddScoped<IFileManager, FileManager>();

            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(UnicodeRanges.BasicLatin,UnicodeRanges.Arabic)
                );

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}