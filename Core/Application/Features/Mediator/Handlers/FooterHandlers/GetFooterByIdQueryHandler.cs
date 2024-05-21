using Application.Features.Mediator.Queries.FooterQueries;
using Application.Features.Mediator.Results.FooterResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterHandlers
{
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<Footer> _repository;

        public GetFooterByIdQueryHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetFooterByIdQueryResult
            {
                FooterID = values.FooterID,
                Description = values.Description,
                Address = values.Address,
                Email = values.Email,
                Phone = values.Phone
            };
        }
    }
}
