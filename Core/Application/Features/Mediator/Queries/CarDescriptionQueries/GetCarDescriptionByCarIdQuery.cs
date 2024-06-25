using Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<List<GetCarDescriptionByCarIdQueryResult>>
    {
        public string Id { get; set; }

        public GetCarDescriptionByCarIdQuery(string id)
        {
            Id = id;
        }
    }
}
