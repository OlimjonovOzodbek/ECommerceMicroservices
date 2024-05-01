using MediatR;
using ShoppingCart.Domain.DTOs;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.UseCases.ShoppingCartCases.Commands
{
    public class UpdateShoppingCartCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
