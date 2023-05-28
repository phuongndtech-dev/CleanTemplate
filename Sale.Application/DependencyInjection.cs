using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Sale.Application.DTO.Customers;
using Sale.Application.Services.Customers;

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

            return services;
        }

        public static IServiceCollection AddLibraries(this IServiceCollection services)
        {
            services.AddFluentValidation();
            services.AddTransient<IValidator<AddOrUpdateCustomerDTO>, AddOrUpdateCustomerValidator>();
            return services;
        }
    }
}
