using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _carRepository.ListCarWithBrandAsync();

            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.BrandName,
                Model = x.Model,
                Image = x.Image,
                Kilometers = x.Kilometers,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel,
                BigImage = x.BigImage
            }).ToList();
        }
    }
}
