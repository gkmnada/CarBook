using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingByIdQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetCarPricingByIdQueryResult
            {
                CarPricingID = values.CarPricingID,
                CarID = values.CarID,
                PricingID = values.PricingID,
                Amount = values.Amount,
            };
        }
    }
}
