using Application.Features.Mediator.Results.FooterResults;
using MediatR;

namespace Application.Features.Mediator.Queries.FooterQueries
{
    public class GetFooterByIdQuery : IRequest<GetFooterByIdQueryResult>
    {
        public string Id { get; set; }

        public GetFooterByIdQuery(string id)
        {
            Id = id;
        }
    }
}
