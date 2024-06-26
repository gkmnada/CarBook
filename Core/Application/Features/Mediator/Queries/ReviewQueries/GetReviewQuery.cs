using Application.Features.Mediator.Results.ReviewResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewQuery : IRequest<List<GetReviewQueryResult>>
    {
        public string Id { get; set; }

        public GetReviewQuery(string id)
        {
            Id = id;
        }
    }
}
