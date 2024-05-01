using Discount.Application.Abstractions;
using Discount.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure
{
    public static class DiscountInfrastructureDependencyInjection
    {
        public static IServiceCollection AddDiscountInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDiscountDbContext, DiscountDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DiscountConnection"));
            });

            return services;
        }
    }
}
