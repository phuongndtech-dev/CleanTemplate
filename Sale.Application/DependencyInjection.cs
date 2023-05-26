using Microsoft.Extensions.DependencyInjection;
using Sale.Application.Services.Customers;

namespace Sale.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
