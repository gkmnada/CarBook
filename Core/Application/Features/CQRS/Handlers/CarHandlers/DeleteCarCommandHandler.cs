using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class DeleteCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public DeleteCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCarCommand deleteCarCommand)
        {
            var values = await _repository.GetAsync(deleteCarCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
