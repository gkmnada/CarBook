using Application.Features.Mediator.Queries.SocialMediaQueries;
using Application.Features.Mediator.Results.SocialMediaResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetSocialMediaQueryResult
            {
                SocialMediaID = x.SocialMediaID,
                Name = x.Name,
                Address = x.Address,
                Icon = x.Icon
            }).ToList();
        }
    }
}
