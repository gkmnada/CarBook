using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public DeleteSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);
            await _repository.DeleteAsync(values);
            return Unit.Value;
        }
    }
}
