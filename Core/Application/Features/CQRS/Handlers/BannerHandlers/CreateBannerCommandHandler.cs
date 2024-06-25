using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand createBannerCommand)
        {
            await _repository.CreateAsync(new Banner
            {
                Title = createBannerCommand.Title,
                Description = createBannerCommand.Description,
                Image = createBannerCommand.Image
            });
        }
    }
}
