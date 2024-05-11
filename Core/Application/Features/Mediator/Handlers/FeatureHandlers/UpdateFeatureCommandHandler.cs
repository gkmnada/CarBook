using MediatR;
using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.FeatureID);
            values.FeatureName = request.FeatureName;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
