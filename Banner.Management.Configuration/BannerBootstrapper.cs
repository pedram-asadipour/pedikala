using _01_Framework.Infrastructure;
using Banner.Management.Configuration.Permission;
using BannerManagement.Application;
using BannerManagement.ApplicationContract.Slider;
using BannerManagement.Domain.SliderAgg;
using BannerManagement.Infrastructure.EFCore;
using BannerManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Banner.Management.Configuration
{
    public static class BannerBootstrapper
    {
        public static void AddBannerConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<BannerContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            #region Slider

            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISliderApplication, SliderApplication>();

            #endregion

            #region Permission

            services.AddSingleton<IPermissionExposer, BannerPermissionExposer>();

            #endregion
        }
    }
}
