using Application.Features.Mediator.Queries.CarDescriptionQueries;
using Application.Features.Mediator.Results.CarDescriptionResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, List<GetCarDescriptionByCarIdQueryResult>>
    {
        private readonly IRepository<CarDescription> _repository;

        public GetCarDescriptionByCarIdQueryHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarDescriptionByCarIdQueryResult>> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListByFilterAsync(x => x.CarID == request.Id);

            return values.Select(x => new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionID = x.CarDescriptionID,
                CarID = x.CarID,
                Description = x.Description
            }).ToList();
        }
    }
}
