using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Application.UseCases.ShoppingCartCases.Commands;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.ShoppingCartCases.Handlers.CommandHandlers
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, ResponseModel>
    {
        private readonly IShoppingCartDbContext _context;

        public UpdateShoppingCartCommandHandler(IShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Shoppings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (cart != null)
            {
                cart.UserId = request.UserId;
                cart.Products = request.Products;
                cart.TotalPrice = request.TotalPrice;

                _context.Shoppings.Update(cart);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"ShoppingCart Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "ShoppingCart is not found",
                StatusCode = 400
            };
        }
    }
}
