using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Features.Mediator.Results.CarRentalResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarRentalQueryHandler : IRequestHandler<GetCarPricingWithCarRentalQuery, List<GetCarPricingWithCarRentalQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarRentalQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarRentalQueryResult>> Handle(GetCarPricingWithCarRentalQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.ListCarPricingWithCarRentalAsync(x => x.LocationID == request.LocationID && x.Available == true);
            return values.Select(x => new GetCarPricingWithCarRentalQueryResult
            {
                CarID = x.CarID,
                BrandName = x.Car.Brand.BrandName,
                Model = x.Car.Model,
                Amount = x.Amount,
                Image = x.Car.Image
            }).ToList();
        }
    }
}
