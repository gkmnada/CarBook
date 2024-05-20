using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                Model = values.Model,
                Image = values.Image,
                Kilometers = values.Kilometers,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Fuel = values.Fuel,
                BigImage = values.BigImage
            };
        }
    }
}
