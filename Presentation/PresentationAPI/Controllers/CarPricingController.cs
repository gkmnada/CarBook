using Application.Features.Mediator.Commands.CarPricingCommands;
using Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListCarPricing()
        {
            var query = new GetCarPricingQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetCarPricing")]
        public async Task<IActionResult> GetCarPricing(string id)
        {
            var query = new GetCarPricingByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarPricing(string id)
        {
            var command = new DeleteCarPricingCommand(id);
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpGet("ListCarPricingWithCar")]
        public async Task<IActionResult> ListCarPricingWithCar()
        {
            var query = new GetCarPricingWithCarQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("ListCarPricingWithCarRental")]
        public async Task<IActionResult> ListCarPricingWithCarRental(string locationID)
        {
            var query = new GetCarPricingWithCarRentalQuery(locationID);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("ListCarPricingWithPeriod")]
        public async Task<IActionResult> ListCarPricingWithPeriod()
        {
            var query = new GetCarPricingWithPeriodQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("ListCarPricingByCar")]
        public async Task<IActionResult> ListCarPricingByCar(string id)
        {
            var query = new GetCarPricingByCarQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
