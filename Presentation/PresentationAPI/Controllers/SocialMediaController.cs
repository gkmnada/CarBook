using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListSocialMedia()
        {
            var query = new GetSocialMediaQuery();
            var values = await _mediator.Send(query);
            return Ok(values);
        }

        [HttpGet("GetSocialMedia")]
        public async Task<IActionResult> GetSocialMedia(string id)
        {

            var query = new GetSocialMediaByIdQuery(id);
            var value = await _mediator.Send(query);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(string id)
        {
            var command = new DeleteSocialMediaCommand(id);
            await _mediator.Send(command);
            return Ok("Başarılı");
        }
    }
}
