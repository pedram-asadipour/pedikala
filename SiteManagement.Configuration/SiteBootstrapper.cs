using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Application;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Configuration.Permission;
using SiteManagement.Domain.ContactUsAgg;
using SiteManagement.Infrastructure.EFCore;
using SiteManagement.Infrastructure.EFCore.Repository;

namespace SiteManagement.Configuration
{
    public static class SiteBootstrapper
    {
        public static void AddSiteConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<SiteContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            #region ContactUs

            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsInfoRepository, ContactUsInfoRepository>();
            services.AddScoped<IContactUsApplication, ContactUsApplication>();

            #endregion

            #region Permisson

            services.AddSingleton<IPermissionExposer, SitePermissionExposer>();

            #endregion
        }
    }
}