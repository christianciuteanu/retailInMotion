using Microsoft.Extensions.DependencyInjection;
using RetailInMotion.OrdersManagement.Core.Interfaces;
using RetailInMotion.OrdersManagement.Infrastructure.Persistance;

namespace RetailInMotion.OrdersManagement.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            return services;
        }
    }
}
