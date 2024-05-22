using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.ListCarPricingWithCarAsync();

            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarID = x.CarID,
                PricingID = x.PricingID,
                BrandName = x.Car.Brand.BrandName,
                Model = x.Car.Model,
                Amount = x.Amount,
                Image = x.Car.Image
            }).ToList();
        }
    }
}
