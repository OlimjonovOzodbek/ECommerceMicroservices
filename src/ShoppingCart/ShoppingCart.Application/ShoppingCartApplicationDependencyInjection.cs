using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShoppingCart.Application
{
    public static class ShoppingCartApplicationDependencyInjection
    {
        public static IServiceCollection AddShoppingCartApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
