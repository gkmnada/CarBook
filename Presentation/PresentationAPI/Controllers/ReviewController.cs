using Application.Features.Mediator.Commands.ReviewCommands;
using Application.Features.Mediator.Queries.ReviewQueries;
using Application.ValidationRules.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListReview(string id)
        {
            var request = new GetReviewQuery(id);
            var values = await _mediator.Send(request);
            return Ok(values);
        }

        [HttpGet("GetReview")]
        public async Task<IActionResult> GetReview(string id)
        {
            var request = new GetReviewByIdQuery(id);
            var values = await _mediator.Send(request);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            CreateReviewValidator validator = new CreateReviewValidator();
            var result = validator.Validate(command);
            if (result.IsValid)
            {
                await _mediator.Send(command);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            UpdateReviewValidator validator = new UpdateReviewValidator();
            var result = validator.Validate(command);
            if (result.IsValid)
            {
                await _mediator.Send(command);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReview(string id)
        {
            var request = new DeleteReviewCommand(id);
            await _mediator.Send(request);
            return Ok("Başarılı");
        }

        [HttpGet("GetReviewCountByCar")]
        public async Task<IActionResult> GetReviewCountByCar(string id)
        {
            var request = new GetReviewCountByCarQuery(id);
            var values = await _mediator.Send(request);
            return Ok(values);
        }
    }
}
