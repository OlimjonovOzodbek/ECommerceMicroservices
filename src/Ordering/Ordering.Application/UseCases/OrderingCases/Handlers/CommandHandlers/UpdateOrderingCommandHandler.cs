using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Abstractions;
using Ordering.Application.UseCases.OrderingCases.Commands;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.UseCases.OrderingCases.Handlers.CommandHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand, ResponseModel>
    {
        private readonly IOrderingDbContext _context;

        public UpdateOrderingCommandHandler(IOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orderings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                order.OrderDate = request.OrderDate;
                order.Status = request.Status;
                order.TotalPrice = request.TotalPrice;
                order.PaymentMethod = request.PaymentMethod;

                _context.Orderings.Update(order);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Order is not found",
                StatusCode = 400
            };
        }
    }
}
