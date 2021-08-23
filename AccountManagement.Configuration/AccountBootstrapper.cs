using AccountManagement.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public static class AccountBootstrapper
    {
        public static void AddAccountConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<AccountContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            #region Account

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountApplication, AccountApplication>();

            #endregion

            #region RoleName

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleApplication, RoleApplication>();

            #endregion
        }
    }
}
