using Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace Application.Features.Mediator.Queries.FeatureQueries
{
    public class ListFeatureQuery : IRequest<List<ListFeatureQueryResult>>
    {
    }
}
