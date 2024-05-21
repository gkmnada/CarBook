using Application.Features.Mediator.Commands.PricingCommands;
using Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListPricing()
        {
            var query = new GetPricingQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetPricing")]
        public async Task<IActionResult> GetPricing(string id)
        {
            var query = new GetPricingByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePricing(string id)
        {
            var command = new DeletePricingCommand(id);
            await _mediator.Send(command);
            return Ok("Başarılı");
        }
    }
}
