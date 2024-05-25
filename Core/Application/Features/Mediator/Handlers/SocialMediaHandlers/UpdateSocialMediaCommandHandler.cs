using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.SocialMediaID);

            values.Name = request.Name;
            values.Address = request.Address;
            values.Icon = request.Icon;

            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
