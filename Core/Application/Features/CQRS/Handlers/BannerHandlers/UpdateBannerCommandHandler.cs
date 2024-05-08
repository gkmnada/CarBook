using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
            var values = await _repository.GetAsync(updateBannerCommand.BannerID);
            values.Title = updateBannerCommand.Title;
            values.Description = updateBannerCommand.Description;
            values.VideoDescription = updateBannerCommand.VideoDescription;
            values.Video = updateBannerCommand.Video;
            await _repository.UpdateAsync(values);
        }
    }
}
