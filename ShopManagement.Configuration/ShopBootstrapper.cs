using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Configuration.Permission;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Infrastructure.Inventory.ACL;

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

            #region Shop Permission

            services.AddSingleton<IPermissionExposer, ShopPermissionExposer>();

            #endregion

            #region Cart

            services.AddSingleton<ICartService, CartService>();

            #endregion

            #region Order

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderApplication, OrderApplication>();

            #endregion

            #region Shop Inventory ACL

            services.AddScoped<IShopInventoryAcl, ShopInventoryAcl>();

            #endregion
        }
    }
}