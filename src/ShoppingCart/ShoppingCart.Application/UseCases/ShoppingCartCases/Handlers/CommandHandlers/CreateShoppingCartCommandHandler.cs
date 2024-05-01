using MediatR;
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
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ResponseModel>
    {
        private readonly IShoppingCartDbContext _context;

        public CreateShoppingCartCommandHandler(IShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var cart = new ProductShoppingCart
                {
                    UserId = request.UserId,
                    Products = request.Products,
                    TotalPrice = request.TotalPrice
                };

                await _context.Shoppings.AddAsync(cart, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"ShoppingCart Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "ShoppingCart is might be null",
                StatusCode = 400
            };
        }
    }
}
