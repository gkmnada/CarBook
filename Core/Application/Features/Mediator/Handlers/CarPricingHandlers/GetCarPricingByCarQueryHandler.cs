using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByCarQueryHandler : IRequestHandler<GetCarPricingByCarQuery, List<GetCarPricingByCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingByCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingByCarQueryResult>> Handle(GetCarPricingByCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.ListCarPricingByCarAsync(request.Id);

            return values.Select(x => new GetCarPricingByCarQueryResult
            {
                CarPricingID = x.CarPricingID,
                CarID = x.CarID,
                Brand = x.Car.Brand.BrandName,
                Model = x.Car.Model,
                Period = x.Pricing.Name,
                Amount = x.Amount
            }).ToList();
        }
    }
}
