using Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public string Id { get; set; }

        public GetSocialMediaByIdQuery(string id)
        {
            Id = id;
        }
    }
}
