using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByIdQuery : IRequest<GetCarPricingByIdQueryResult>
    {
        public string Id { get; set; }

        public GetCarPricingByIdQuery(string id)
        {
            Id = id;
        }
    }
}
