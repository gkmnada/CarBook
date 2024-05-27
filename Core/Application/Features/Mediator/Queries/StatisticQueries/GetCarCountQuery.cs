using Application.Features.Mediator.Results.StatisticResults;
using MediatR;

namespace Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountQuery : IRequest<GetCarCountQueryResult>
    {
    }
}
