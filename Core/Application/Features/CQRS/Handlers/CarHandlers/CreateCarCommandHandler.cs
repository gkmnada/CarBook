using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand createCarCommand)
        {
            await _repository.CreateAsnyc(new Car
            {
                BrandID = createCarCommand.BrandID,
                Model = createCarCommand.Model,
                Image = createCarCommand.Image,
                Kilometers = createCarCommand.Kilometers,
                Transmission = createCarCommand.Transmission,
                Seat = createCarCommand.Seat,
                Luggage = createCarCommand.Luggage,
                Fuel = createCarCommand.Fuel,
                BigImage = createCarCommand.BigImage
            });
        }
    }
}
