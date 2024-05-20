using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetCarQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
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
