using _01_Framework.Infrastructure;
using DiscountManagement.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Configuration.Permission;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public static class DiscountBootstrapper
    {
        public static void AddDiscountConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<DiscountContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            #region Customer Discount

            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddScoped<ICustomerDiscountApplication, CustomerDiscountApplication>();

            #endregion

            #region Colleague Discount

            services.AddScoped<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            services.AddScoped<IColleagueDiscountApplication, ColleagueDiscountApplication>();

            #endregion

            #region Permission

            services.AddSingleton<IPermissionExposer, DiscountPermissionExposer>();

            #endregion
        }
    }
}
