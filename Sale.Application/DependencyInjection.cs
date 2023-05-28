using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Sale.Application.DTO.Customers;
using Sale.Application.DTO.Products;
using Sale.Application.DTO.Shops;
using Sale.Application.Services.Customers;
using Sale.Application.Services.Products;
using Sale.Application.Services.Shops;

namespace Sale.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            services.AddLibraries();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddLibraries(this IServiceCollection services)
        {
            services.AddFluentValidation();
            services.AddTransient<IValidator<AddOrUpdateCustomerDTO>, AddOrUpdateCustomerValidator>();
            services.AddTransient<IValidator<AddOrUpdateProductDTO>, AddOrUpdateProductValidator>();
            services.AddTransient<IValidator<AddOrUpdateShopDTO>, AddOrUpdateShopValidator>();
            return services;
        }
    }
}
