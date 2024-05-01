using Discount.Application.Abstractions;
using Discount.Application.UseCases.DiscountCases.Commands;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.DiscountCases.Handlers.CommandHandlers
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;

        public UpdateDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (discount != null)
            {
                discount.ProductId = request.ProductId;
                discount.CouponCode = request.CouponCode;
                discount.StartDate = request.StartDate;
                discount.EndDate = request.EndDate;

                _context.Discounts.Update(discount);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Discount Updated",
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
