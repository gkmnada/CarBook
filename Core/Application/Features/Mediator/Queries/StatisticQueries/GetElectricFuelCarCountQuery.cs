using Application.Features.Mediator.Results.StatisticResults;
using MediatR;

namespace Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetElectricFuelCarCountQuery : IRequest<GetElectricFuelCarCountQueryResult>
    {
    }
}
