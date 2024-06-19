using Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarRentalQuery : IRequest<List<GetCarPricingWithCarRentalQueryResult>>
    {
        public string LocationID { get; set; }

        public GetCarPricingWithCarRentalQuery(string locationID)
        {
            LocationID = locationID;
        }
    }
}
