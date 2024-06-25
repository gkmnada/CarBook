using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateAvailableToFalseCommandHandler : IRequestHandler<UpdateAvailableToFalseCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateAvailableToFalseCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<Unit> Handle(UpdateAvailableToFalseCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.UpdateAvailableToFalseAsync(request.Id);
            return Unit.Value;
        }
    }
}
