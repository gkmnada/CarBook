using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class DeleteBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public DeleteBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBannerCommand deleteBannerCommand)
        {
            var values = await _repository.GetAsync(deleteBannerCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
