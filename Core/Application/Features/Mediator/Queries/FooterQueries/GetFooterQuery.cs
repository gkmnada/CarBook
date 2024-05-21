using Application.Features.Mediator.Results.FooterResults;
using MediatR;

namespace Application.Features.Mediator.Queries.FooterQueries
{
    public class GetFooterQuery : IRequest<List<GetFooterQueryResult>>
    {
    }
}
