using Application.Features.Mediator.Commands.FooterCommands;
using Application.Features.Mediator.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListFooter()
        {
            var query = new GetFooterQuery();
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("GetFooter")]
        public async Task<IActionResult> GetFooter(string id)
        {
            var query = new GetFooterByIdQuery(id);
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterCommand command)
        {
            var values = await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand command)
        {
            var values = await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooter(string id)
        {
            var command = new DeleteFooterCommand(id);
            var values = await _mediator.Send(command);
            return Ok("Başarılı");
        }
    }
}
