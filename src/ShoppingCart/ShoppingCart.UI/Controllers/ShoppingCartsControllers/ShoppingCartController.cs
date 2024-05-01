using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.UseCases.ShoppingCartCases.Commands;
using ShoppingCart.Application.UseCases.ShoppingCartCases.Queries;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.UI.Controllers.ShoppingCartsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingCart(CreateShoppingCartCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductShoppingCart>>> GetAllOrders()
        {
            var result = await _mediator.Send(new GetAllShoppingCartsQuery());

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteShoppingCartCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateShoppingCartCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
