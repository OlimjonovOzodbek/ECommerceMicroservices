using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.QueryHandlers
{
    public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, List<ProductCatalog>>
    {
        private readonly ICatalogDbContext _context;

        public GetAllCatalogsQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCatalog>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Catalogs.ToListAsync(cancellationToken);
        }
    }
}
