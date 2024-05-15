using Application.Features.Mediator.Queries.ServiceQueries;
using Application.Features.Mediator.Results.ServiceResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetServiceByIdQueryResult
            {
                ServiceID = values.ServiceID,
                Title = values.Title,
                Description = values.Description,
                Icon = values.Icon
            };
        }
    }
}
