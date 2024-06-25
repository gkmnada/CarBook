using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public CreateCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarFeature
            {
                CarID = request.CarID,
                FeatureID = request.FeatureID,
                Available = true
            });

            return Unit.Value;
        }
    }
}
