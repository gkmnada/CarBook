using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class DeleteAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public DeleteAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAboutCommand deleteAboutCommand)
        {
            var values = await _repository.GetAsync(deleteAboutCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
