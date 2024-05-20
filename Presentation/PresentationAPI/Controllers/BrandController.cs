using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly DeleteBrandCommandHandler _deleteBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

        public BrandController(GetBrandQueryHandler getBrandQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, DeleteBrandCommandHandler deleteBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _deleteBrandCommandHandler = deleteBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ListBrand()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand(string id)
        {
            var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
        {
            await _createBrandCommandHandler.Handle(createBrandCommand);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand updateBrandCommand)
        {
            await _updateBrandCommandHandler.Handle(updateBrandCommand);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _deleteBrandCommandHandler.Handle(new DeleteBrandCommand(id));
            return Ok("Başarılı");
        }
    }
}
