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

        [HttpGet("GetAutomaticTransmissionCarCount")]
        public async Task<IActionResult> GetAutomaticTransmissionCarCount()
        {
            var request = new GetAutomaticTransmissionCarCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetManuelTransmissionCarCount")]
        public async Task<IActionResult> GetManuelTransmissionCarCount()
        {
            var request = new GetManuelTransmissionCarCountQuery();
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

        [HttpGet("GetCarByDailyMinPrice")]
        public async Task<IActionResult> GetCarByDailyMinPrice()
        {
            var request = new GetCarByDailyMinPriceQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetCarByDailyMaxPrice")]
        public async Task<IActionResult> GetCarByDailyMaxPrice()
        {
            var request = new GetCarByDailyMaxPriceQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetCarByWeeklyMinPrice")]
        public async Task<IActionResult> GetCarByWeeklyMinPrice()
        {
            var request = new GetCarByWeeklyMinPriceQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetCarByWeeklyMaxPrice")]
        public async Task<IActionResult> GetCarByWeeklyMaxPrice()
        {
            var request = new GetCarByWeeklyMaxPriceQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetCarByMonthlyMinPrice")]
        public async Task<IActionResult> GetCarByMonthlyMinPrice()
        {
            var request = new GetCarByMonthlyMinPriceQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetCarByMonthlyMaxPrice")]
        public async Task<IActionResult> GetCarByMonthlyMaxPrice()
        {
            var request = new GetCarByMonthlyMaxPriceQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetDieselFuelCarCount")]
        public async Task<IActionResult> GetDieselFuelCarCount()
        {
            var request = new GetDieselFuelCarCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetGasolineFuelCarCount")]
        public async Task<IActionResult> GetGasolineFuelCarCount()
        {
            var request = new GetGasolineFuelCarCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetElectricFuelCarCount")]
        public async Task<IActionResult> GetElectricFuelCarCount()
        {
            var request = new GetElectricFuelCarCountQuery();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
