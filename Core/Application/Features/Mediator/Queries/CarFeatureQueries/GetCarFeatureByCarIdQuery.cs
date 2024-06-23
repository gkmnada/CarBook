using Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public string Id { get; set; }

        public GetCarFeatureByCarIdQuery(string id)
        {
            Id = id;
        }
    }
}
