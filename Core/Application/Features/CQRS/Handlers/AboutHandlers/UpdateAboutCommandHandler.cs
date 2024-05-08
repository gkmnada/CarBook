using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var values = await _repository.GetAsync(updateAboutCommand.AboutID);
            values.Title = updateAboutCommand.Title;
            values.Description = updateAboutCommand.Description;
            values.Image = updateAboutCommand.Image;
            await _repository.UpdateAsync(values);
        }
    }
}
