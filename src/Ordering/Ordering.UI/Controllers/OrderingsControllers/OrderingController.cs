using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.UseCases.OrderingCases.Commands;
using Ordering.Application.UseCases.OrderingCases.Queries;
using Ordering.Domain.Entities;

namespace Ordering.UI.Controllers.OrderingsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductOrdering>>> GetAllOrders()
        {
            var result = await _mediator.Send(new GetAllOrderingsQuery());

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
