using Discount.Application.Abstractions;
using Discount.Application.UseCases.DiscountCases.Commands;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Discount.Application.UseCases.DiscountCases.Handlers.CommandHandlers
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;

        public DeleteDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Discount Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Discount is not found",
                StatusCode = 400
            };
        }
    }
}
