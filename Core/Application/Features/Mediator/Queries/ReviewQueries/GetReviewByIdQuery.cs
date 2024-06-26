using Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByIdQuery : IRequest<GetReviewByIdQueryResult>
    {
        public string Id { get; }

        public GetReviewByIdQuery(string id)
        {
            Id = id;
        }
    }
}
