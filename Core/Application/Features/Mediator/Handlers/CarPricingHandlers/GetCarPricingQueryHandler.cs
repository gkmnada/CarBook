using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetCarPricingQueryResult
            {
                CarPricingID = x.CarPricingID,
                CarID = x.CarID,
                PricingID = x.PricingID,
                Amount = x.Amount,
            }).ToList();
        }
    }
}
