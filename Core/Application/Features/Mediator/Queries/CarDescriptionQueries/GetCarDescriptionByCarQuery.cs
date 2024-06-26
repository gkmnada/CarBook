using Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarQuery : IRequest<GetCarDescriptionByCarQueryResult>
    {
        public string Id { get; set; }

        public GetCarDescriptionByCarQuery(string id)
        {
            Id = id;
        }
    }
}
