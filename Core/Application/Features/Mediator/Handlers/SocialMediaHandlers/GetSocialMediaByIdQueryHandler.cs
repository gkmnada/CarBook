using Application.Features.Mediator.Queries.SocialMediaQueries;
using Application.Features.Mediator.Results.SocialMediaResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaID = values.SocialMediaID,
                Name = values.Name,
                Address = values.Address,
                Icon = values.Icon
            };
        }
    }
}
