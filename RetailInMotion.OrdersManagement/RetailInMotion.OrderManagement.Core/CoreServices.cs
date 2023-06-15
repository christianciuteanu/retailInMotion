using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RetailInMotion.OrdersManagement.Core
{
    public static class CoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CoreServices));

            return services;
        }
    }
}
