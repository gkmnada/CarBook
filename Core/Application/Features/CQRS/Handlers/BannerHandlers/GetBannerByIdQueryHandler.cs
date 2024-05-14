using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetAsync(query.Id);

            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Title = values.Title,
                Description = values.Description,
                Video = values.Video,
                VideoDescription = values.VideoDescription,
            };
        }
    }
}
