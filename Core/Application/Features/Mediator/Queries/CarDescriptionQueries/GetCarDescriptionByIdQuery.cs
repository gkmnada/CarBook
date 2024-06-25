using Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByIdQuery : IRequest<GetCarDescriptionByIdQueryResult>
    {
        public string Id { get; set; }

        public GetCarDescriptionByIdQuery(string id)
        {
            Id = id;
        }
    }
}
