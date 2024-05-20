using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var values = await _repository.GetAsync(updateCarCommand.CarID);
            values.BrandID = updateCarCommand.BrandID;
            values.Model = updateCarCommand.Model;
            values.Image = updateCarCommand.Image;
            values.Kilometers = updateCarCommand.Kilometers;
            values.Transmission = updateCarCommand.Transmission;
            values.Seat = updateCarCommand.Seat;
            values.Luggage = updateCarCommand.Luggage;
            values.Fuel = updateCarCommand.Fuel;
            values.BigImage = updateCarCommand.BigImage;

            await _repository.UpdateAsync(values);
        }
    }
}
