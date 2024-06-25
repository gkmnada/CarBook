using Application.Features.Mediator.Queries.CarDescriptionQueries;
using Application.Features.Mediator.Results.CarDescriptionResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, List<GetCarDescriptionQueryResult>>
    {
        private readonly IRepository<CarDescription> _repository;

        public GetCarDescriptionQueryHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarDescriptionQueryResult>> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetCarDescriptionQueryResult
            {
                CarDescriptionID = x.CarDescriptionID,
                CarID = x.CarID,
                Description = x.Description
            }).ToList();
        }
    }
}
