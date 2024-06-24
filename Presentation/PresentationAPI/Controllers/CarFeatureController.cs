using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListCarFeatureByCarId(string id)
        {
            var query = new GetCarFeatureByCarIdQuery(id);
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureCommand command)
        {
            var values = await _mediator.Send(command);
            return Ok("Başarılı");
        }
    }
}
