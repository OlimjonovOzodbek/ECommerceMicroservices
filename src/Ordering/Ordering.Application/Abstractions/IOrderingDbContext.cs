using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Abstractions
{
    public interface IOrderingDbContext
    {
        public DbSet<ProductOrdering> Orderings { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
