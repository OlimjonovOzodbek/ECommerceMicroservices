using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Abstractions;
using Ordering.Infrastructure.Persistance;

namespace Ordering.Infrastructure
{
    public static class OrderingInfrastructureDependencyInjection
    {
        public static IServiceCollection AddOrderingInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IOrderingDbContext, OrderingDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("OrderingConnection"));
            });

            return services;
        }
    }
}
