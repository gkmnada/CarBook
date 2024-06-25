using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandByIdQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarWithBrandByIdQueryResult> Handle(GetCarWithBrandByIdQuery request)
        {
            var values = await _carRepository.GetCarWithBrandAsync(request.Id);

            return new GetCarWithBrandByIdQueryResult
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                BrandName = values.Brand.BrandName,
                Model = values.Model,
                Image = values.Image,
                Kilometers = values.Kilometers,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Fuel = values.Fuel,
                BigImage = values.BigImage,
            };
        }
    }
}
