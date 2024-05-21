using Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public string Id { get; set; }

        public GetPricingByIdQuery(string id)
        {
            Id = id;
        }
    }
}
