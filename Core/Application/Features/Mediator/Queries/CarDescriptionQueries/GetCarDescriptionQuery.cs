using Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery : IRequest<List<GetCarDescriptionQueryResult>>
    {
    }
}
