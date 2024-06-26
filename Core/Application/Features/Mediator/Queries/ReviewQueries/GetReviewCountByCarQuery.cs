using Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewCountByCarQuery : IRequest<GetReviewCountByCarQueryResult>
    {
        public string Id { get; set; }

        public GetReviewCountByCarQuery(string id)
        {
            Id = id;
        }
    }
}
