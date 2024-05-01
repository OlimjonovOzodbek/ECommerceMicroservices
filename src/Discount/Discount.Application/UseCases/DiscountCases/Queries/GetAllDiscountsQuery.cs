using Discount.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.DiscountCases.Queries
{
    public class GetAllDiscountsQuery : IRequest<List<ProductDiscount>>
    {
    }
}
