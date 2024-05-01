using MediatR;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.OrderingCases.Commands
{
    public class DeleteOrderingCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
