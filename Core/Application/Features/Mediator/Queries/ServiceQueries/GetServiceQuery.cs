using Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {
    }
}
