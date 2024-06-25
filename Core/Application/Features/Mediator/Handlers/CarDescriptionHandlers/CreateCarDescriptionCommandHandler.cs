using Application.Features.Mediator.Commands.CarDescriptionCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarDescription
            {
                CarID = request.CarID,
                Description = request.Description
            });

            return Unit.Value;
        }
    }
}
