using Microsoft.EntityFrameworkCore;
using Ordering.Application.Abstractions;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderingDbContext : DbContext, IOrderingDbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }
        public DbSet<ProductOrdering> Orderings { get; set; }
    }
}
