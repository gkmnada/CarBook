using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateAvailableToTrueCommandHandler : IRequestHandler<UpdateAvailableToTrueCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateAvailableToTrueCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<Unit> Handle(UpdateAvailableToTrueCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.UpdateAvailableToTrueAsync(request.Id);
            return Unit.Value;
        }
    }
}
