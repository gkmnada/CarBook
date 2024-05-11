using Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery : IRequest<GetFeatureQueryResult>
    {
        public GetFeatureQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
