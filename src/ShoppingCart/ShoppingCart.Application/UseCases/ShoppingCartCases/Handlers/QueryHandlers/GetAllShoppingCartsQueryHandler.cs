using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Application.UseCases.ShoppingCartCases.Queries;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.ShoppingCartCases.Handlers.QueryHandlers
{
    public class GetAllShoppingCartsQueryHandler : IRequestHandler<GetAllShoppingCartsQuery, List<ProductShoppingCart>>
    {
        private readonly IShoppingCartDbContext _context;

        public GetAllShoppingCartsQueryHandler(IShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductShoppingCart>> Handle(GetAllShoppingCartsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Shoppings.ToListAsync(cancellationToken);
        }
    }
}
