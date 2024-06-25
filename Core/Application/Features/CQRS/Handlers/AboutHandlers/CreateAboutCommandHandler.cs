using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand createAboutCommand)
        {
            await _repository.CreateAsync(new About
            {
                Title = createAboutCommand.Title,
                Description = createAboutCommand.Description,
                Image = createAboutCommand.Image
            });
        }
    }
}
