using MediatR;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.OrderingCases.Commands
{
    public class UpdateOrderingCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Status { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
    }
}
