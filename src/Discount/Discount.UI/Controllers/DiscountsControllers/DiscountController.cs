using Discount.Application.UseCases.DiscountCases.Commands;
using Discount.Application.UseCases.DiscountCases.Queries;
using Discount.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Discount.UI.Controllers.DiscountsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDiscount>>> GetAllDiscounts()
        {
            var result = await _mediator.Send(new GetAllDiscountsQuery());

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(DeleteDiscountCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
