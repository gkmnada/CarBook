using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerQueryResult> Handle(GetBannerQuery query)
        {
            var values = await _repository.GetAsync(query.Id);
            return new GetBannerQueryResult
            {
                BannerID = values.BannerID,
                Title = values.Title,
                Description = values.Description,
                VideoDescription = values.VideoDescription,
                Video = values.Video
            };
        }
    }
}
