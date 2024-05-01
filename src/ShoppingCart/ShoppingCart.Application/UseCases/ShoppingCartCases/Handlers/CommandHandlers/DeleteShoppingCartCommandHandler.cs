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
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, ResponseModel>
    {
        private readonly IShoppingCartDbContext _context;

        public DeleteShoppingCartCommandHandler(IShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _context.Shoppings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (cart != null)
            {
                _context.Shoppings.Remove(cart);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"ShoppingCart Deleted",
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
