using Application.Features.Mediator.Queries.ServiceQueries;
using Application.Features.Mediator.Results.ServiceResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetServiceQueryResult
            {
                ServiceID = x.ServiceID,
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon
            }).ToList();
        }
    }
}