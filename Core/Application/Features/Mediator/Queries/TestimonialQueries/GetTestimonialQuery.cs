using Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
