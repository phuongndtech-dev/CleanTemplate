using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sale.Application.DTO.Customers;
using Sale.Application.DTO.Products;
using Sale.Application.DTO.Shops;
using Sale.Application.Exception.Customers;
using Sale.Application.Exception.Products;
using Sale.Application.Exception.Shops;
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
            services.AddProblemDetails(setup =>
            {
                setup.Map<CustomerCustomException>(exception => new CustomerCustomDetails
                {
                    Title = exception.Title,
                    Detail = exception.Detail,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = exception.Type,
                    Instance = exception.Instance,
                    AdditionalInfo = exception.AdditionalInfo
                });

                setup.Map<ProductCustomException>(exception => new ProductCustomDetails
                {
                    Title = exception.Title,
                    Detail = exception.Detail,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = exception.Type,
                    Instance = exception.Instance,
                    AdditionalInfo = exception.AdditionalInfo
                });

                setup.Map<ShopCustomException>(exception => new ShopCustomDetails
                {
                    Title = exception.Title,
                    Detail = exception.Detail,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = exception.Type,
                    Instance = exception.Instance,
                    AdditionalInfo = exception.AdditionalInfo
                });
            });
            services.AddFluentValidationAutoValidation();
            services.AddTransient<IValidator<AddOrUpdateCustomerDTO>, AddOrUpdateCustomerValidator>();
            services.AddTransient<IValidator<AddOrUpdateProductDTO>, AddOrUpdateProductValidator>();
            services.AddTransient<IValidator<AddOrUpdateShopDTO>, AddOrUpdateShopValidator>();
            return services;
        }
    }
}
