using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class ListBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public ListBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<ListBannerQueryResult>> Handle()
        {
            var values = await _repository.ListAsync();
            return values.Select(x => new ListBannerQueryResult
            {
                BannerID = x.BannerID,
                Title = x.Title,
                Description = x.Description,
                VideoDescription = x.VideoDescription,
                Video = x.Video
            }).ToList();
        }
    }
}
