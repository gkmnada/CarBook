using Application.Features.Mediator.Queries.FooterQueries;
using Application.Features.Mediator.Results.FooterResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterHandlers
{
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetFooterQueryResult
            {
                FooterID = x.FooterID,
                Description = x.Description,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();
        }
    }
}
