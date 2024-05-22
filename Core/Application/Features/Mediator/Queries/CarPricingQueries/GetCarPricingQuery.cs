using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingQuery : IRequest<List<GetCarPricingQueryResult>>
    {
    }
}
