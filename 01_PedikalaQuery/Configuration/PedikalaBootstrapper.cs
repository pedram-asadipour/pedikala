using _01_PedikalaQuery.Contract.Article;
using _01_PedikalaQuery.Contract.ArticleCategory;
using _01_PedikalaQuery.Contract.Cart;
using _01_PedikalaQuery.Contract.Inventory;
using _01_PedikalaQuery.Contract.Menu;
using _01_PedikalaQuery.Contract.Product;
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

            #region Product

            services.AddScoped<IProductQuery, ProductQuery>();

            #endregion

            #region Article Category

            services.AddScoped<IArticleCategoryQuery, ArticleCategoryQuery>();

            #endregion

            #region Article

            services.AddScoped<IArticleQuery, ArticleQuery>();

            #endregion

            #region Inventory

            services.AddScoped<IInventoryQuery, InventoryQuery>();

            #endregion

            #region Cart

            services.AddScoped<ICartQuery, CartQuery>();

            #endregion
        }
    }
}