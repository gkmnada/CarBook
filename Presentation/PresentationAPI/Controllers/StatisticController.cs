using Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var request = new GetCarCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var request = new GetLocationCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var request = new GetBrandCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetDailyAveragePricing")]
        public async Task<IActionResult> GetDailyAveragePricing()
        {
            var request = new GetDailyAveragePricingQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetWeeklyAveragePricing")]
        public async Task<IActionResult> GetWeeklyAveragePricing()
        {
            var request = new GetWeeklyAveragePricingQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetMonthlyAveragePricing")]
        public async Task<IActionResult> GetMonthlyAveragePricing()
        {
            var request = new GetMonthlyAveragePricingQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetBrandNameByMostCar")]
        public async Task<IActionResult> GetBrandNameByMostCar()
        {
            var request = new GetBrandNameByMostCarQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
