using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Abstractions;
using Ordering.Application.UseCases.OrderingCases.Queries;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.OrderingCases.Handlers.QueryHandlers
{
    public class GetAllOrderingsQueryHandler : IRequestHandler<GetAllOrderingsQuery, List<ProductOrdering>>
    {
        private readonly IOrderingDbContext _context;

        public GetAllOrderingsQueryHandler(IOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductOrdering>> Handle(GetAllOrderingsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orderings.ToListAsync(cancellationToken);
        }
    }
}
