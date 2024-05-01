using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure.Persistance
{
    public class ShoppingCartDbContext : DbContext, IShoppingCartDbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }
        public DbSet<ProductShoppingCart> Shoppings { get; set; }
    }
}
