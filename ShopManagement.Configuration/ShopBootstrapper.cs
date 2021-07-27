using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configuration
{
    public static class ShopBootstrapper
    {
        public static void AddShopConfigure(this IServiceCollection services, string connection)
        {
            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            #region Product Category

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryApplication, ProductCategoryApplication>();

            #endregion
        }
    }
}