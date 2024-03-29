﻿using System;
using _01_Framework.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Configuration.Permission;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Configuration
{
    public static class InventoryBootstrapper
    {
        public static void AddInventoryConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<InventoryContext>(option =>
            {
                option.UseSqlServer(connection);
            });

            #region Inventory

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryApplication, InventoryApplication>();

            #endregion

            #region Invenroty Permission

            services.AddSingleton<IPermissionExposer, InventoryPermissionExposer>();

            #endregion
        }
    }
}
