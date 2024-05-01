using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public static class ShoppingCartInfrastructureDependencyInjection
    {
        public static IServiceCollection AddShoppingCartInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IShoppingCartDbContext, ShoppingCartDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ShoppingCartConnection"));
            });

            return services;
        }
    }
}
