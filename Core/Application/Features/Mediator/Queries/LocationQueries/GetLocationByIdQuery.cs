using Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public string Id { get; set; }

        public GetLocationByIdQuery(string id)
        {
            Id = id;
        }
    }
}
