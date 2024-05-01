using MediatR;
using Ordering.Application.Abstractions;
using Ordering.Application.UseCases.OrderingCases.Commands;
using Ordering.Domain.Entities;

namespace Ordering.Application.UseCases.OrderingCases.Handlers.CommandHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand, ResponseModel>
    {
        private readonly IOrderingDbContext _context;

        public CreateOrderingCommandHandler(IOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var order = new ProductOrdering
                {
                    OrderDate = request.OrderDate,
                    Status = request.Status,
                    TotalPrice = request.TotalPrice,
                    PaymentMethod = request.PaymentMethod
                };

                await _context.Orderings.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Ordering is might be null",
                StatusCode = 400
            };
        }
    }
}
