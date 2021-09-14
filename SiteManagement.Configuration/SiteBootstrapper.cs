using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Application;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Application.Contract.Footer;
using SiteManagement.Configuration.Permission;
using SiteManagement.Domain.ContactUsAgg;
using SiteManagement.Domain.FooterAgg;
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

            #region Footer

            services.AddScoped<IFooterRepository, FooterRepository>();
            services.AddScoped<IFooterLinkRepository, FooterLinkRepository>();
            services.AddScoped<IFooterApplication, FooterApplication>();

            #endregion

            #region Permisson

            services.AddSingleton<IPermissionExposer, SitePermissionExposer>();

            #endregion
        }
    }
}