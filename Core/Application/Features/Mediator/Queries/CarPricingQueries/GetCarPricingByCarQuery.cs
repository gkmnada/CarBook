using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByCarQuery : IRequest<List<GetCarPricingByCarQueryResult>>
    {
        public string Id { get; set; }

        public GetCarPricingByCarQuery(string id)
        {
            Id = id;
        }
    }
}
