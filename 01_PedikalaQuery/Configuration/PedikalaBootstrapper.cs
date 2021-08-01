using _01_PedikalaQuery.Contract.Menu;
using _01_PedikalaQuery.Contract.ProductCategory;
using _01_PedikalaQuery.Query;
using Microsoft.Extensions.DependencyInjection;

namespace _01_PedikalaQuery.Configuration
{
    public static class PedikalaBootstrapper
    {
        public static void AddQueryConfigure(this IServiceCollection services)
        {
            #region Product Category

            services.AddScoped<IProductCategoryQuery, ProductCategoryQuery>();

            #endregion

            #region Menu

            services.AddScoped<IMenuQuery, MenuQuery>();

            #endregion
        }
    }
}