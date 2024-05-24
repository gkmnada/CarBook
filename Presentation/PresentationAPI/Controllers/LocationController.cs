using Application.Features.Mediator.Commands.LocationCommands;
using Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListLocation()
        {
            var query = new GetLocationQuery();
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetLocation(string id)
        {
            var query = new GetLocationByIdQuery(id);
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var command = new DeleteLocationCommand(id);
            await _mediator.Send(command);
            return Ok("Başarılı");
        }
    }
}
