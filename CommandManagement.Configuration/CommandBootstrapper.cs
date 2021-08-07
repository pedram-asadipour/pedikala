using System;
using CommandManagement.Application;
using CommandManagement.Application.Contract.ProductCommand;
using CommandManagement.Domain.ProductCommandAgg;
using CommandManagement.Infrastructure.EFCore;
using CommandManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommandManagement.Configuration
{
    public static class CommandBootstrapper 
    {
        public static void AddCommandConfigure(this IServiceCollection services ,string connection)
        {
            services.AddDbContext<CommandContext>(options =>
            {
                options.UseSqlServer(connection);
            });


            #region Product Command

            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductCommandApplication, ProductCommandApplication>();

            #endregion
        }
    }
}
