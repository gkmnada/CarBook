using Application.Features.Mediator.Queries.CarDescriptionQueries;
using Application.Features.Mediator.Results.CarDescriptionResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByIdQueryHandler : IRequestHandler<GetCarDescriptionByIdQuery, GetCarDescriptionByIdQueryResult>
    {
        private readonly IRepository<CarDescription> _repository;

        public GetCarDescriptionByIdQueryHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByIdQueryResult> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetCarDescriptionByIdQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Description = values.Description
            };
        }
    }
}
