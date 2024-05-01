using Discount.Application.Abstractions;
using Discount.Application.UseCases.DiscountCases.Queries;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.DiscountCases.Handlers.QueryHandlers
{
    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, List<ProductDiscount>>
    {
        private readonly IDiscountDbContext _context;

        public GetAllDiscountsQueryHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDiscount>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Discounts.ToListAsync(cancellationToken);
        }
    }
}
