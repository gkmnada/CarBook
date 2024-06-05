using Application.Features.Mediator.Results.CarRentalResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarRentalQueries
{
    public class GetCarRentalQuery : IRequest<List<GetCarRentalQueryResult>>
    {
        public string LocationID { get; set; }

        public GetCarRentalQuery(string locationID)
        {
            LocationID = locationID;
        }
    }
}
