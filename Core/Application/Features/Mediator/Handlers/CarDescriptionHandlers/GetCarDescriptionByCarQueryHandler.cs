using Application.Features.Mediator.Queries.CarDescriptionQueries;
using Application.Features.Mediator.Results.CarDescriptionResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarQueryHandler : IRequestHandler<GetCarDescriptionByCarQuery, GetCarDescriptionByCarQueryResult>
    {
        private readonly IRepository<CarDescription> _repository;

        public GetCarDescriptionByCarQueryHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarQueryResult> Handle(GetCarDescriptionByCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.CarID == request.Id);

            return new GetCarDescriptionByCarQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Description = values.Description
            };
        }
    }
}
