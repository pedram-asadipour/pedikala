using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
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

            #region Product

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductApplication, ProductApplication>();

            #endregion

            #region Product Picture

            services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
            services.AddScoped<IProductPictureApplication, ProductPictureApplication>();

            #endregion
        }
    }
}