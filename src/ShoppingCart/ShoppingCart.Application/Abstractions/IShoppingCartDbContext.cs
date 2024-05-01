﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Abstractions
{
    public interface IShoppingCartDbContext
    {
        public DbSet<ProductShoppingCart> Shoppings { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
