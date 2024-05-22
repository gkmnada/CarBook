using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
    {
    }
}
