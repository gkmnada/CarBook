using Application.Features.Mediator.Results.AppUserResults;
using MediatR;

namespace Application.Features.Mediator.Queries.AppUserQueries
{
    public class CheckAppUserQuery : IRequest<CheckAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
