using Application.Features.Mediator.Queries.CarRentalQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarRentalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ListCarRentalByLocation(GetCarRentalQuery query)
        {
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
