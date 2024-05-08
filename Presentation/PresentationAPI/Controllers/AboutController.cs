using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly ListAboutQueryHandler _listAboutQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;

        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, ListAboutQueryHandler listAboutQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, DeleteAboutCommandHandler deleteAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _listAboutQueryHandler = listAboutQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ListAbout()
        {
            var values = await _listAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetAbout")]
        public async Task<IActionResult> GetAbout(string id)
        {
            var values = await _getAboutQueryHandler.Handle(new GetAboutQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _deleteAboutCommandHandler.Handle(new DeleteAboutCommand(id));
            return Ok("Başarılı");
        }
    }
}
