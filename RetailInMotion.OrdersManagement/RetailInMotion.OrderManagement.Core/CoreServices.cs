using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RetailInMotion.OrdersManagement.Core.Interfaces;
using RetailInMotion.OrdersManagement.Core.Services;

namespace RetailInMotion.OrdersManagement.Core
{
    public static class CoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IOrderService, OrderService>();
            services.AddMediatR(typeof(CoreServices));

            return services;
        }
    }
}
