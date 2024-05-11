using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsnyc(new Feature
            {
                FeatureName = request.FeatureName,
            });
            return Unit.Value;
        }
    }
}
