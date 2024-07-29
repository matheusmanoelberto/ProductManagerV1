using ProductManager.Data.Context;
using ProductManager.Data.Repository;
using ProductManager.Domain.Interfaces;
using ProductManager.Domain.Interfaces.Respositories;
using ProductManager.Domain.Interfaces.Services;
using ProductManager.Domain.Notifications;
using ProductManager.Domain.Services;

namespace ProductManager.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<ManagerDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //Domain
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
