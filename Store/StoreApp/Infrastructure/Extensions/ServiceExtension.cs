using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)

        {
            services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
b => b.MigrationsAssembly("StoreApp")
);


});
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreAppSession";
                options.IdleTimeout = TimeSpan.FromMinutes(10);

            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));

        }

        public static void ConfigureRepositoryRegistiration(this IServiceCollection services)
        {

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistiration(this IServiceCollection services)
        {

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IProductService, ProductManager>();
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>{
                options.LowercaseUrls=true;
                options.AppendTrailingSlash=true;
            });
        }
    }

}