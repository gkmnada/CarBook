using Application.Features.Mediator.Commands.CarDescriptionCommands;
using Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListCarDescription()
        {
            var query = new GetCarDescriptionQuery();
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("GetCarDescription")]
        public async Task<IActionResult> GetCarDescription(string id)
        {
            var query = new GetCarDescriptionByIdQuery(id);
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarDescription(CreateCarDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarDescription(UpdateCarDescriptionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarDescription(string id)
        {
            var command = new DeleteCarDescriptionCommand(id);
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpGet("ListCarDescriptionByCar")]
        public async Task<IActionResult> ListCarDescriptionByCar(string id)
        {
            var query = new GetCarDescriptionByCarIdQuery(id);
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("GetCarDescriptionByCar")]
        public async Task<IActionResult> GetCarDescriptionByCar(string id)
        {
            var query = new GetCarDescriptionByCarQuery(id);
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
