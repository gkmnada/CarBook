using Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
    }
}
