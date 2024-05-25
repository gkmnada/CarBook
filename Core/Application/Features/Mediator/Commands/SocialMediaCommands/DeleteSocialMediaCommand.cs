using MediatR;

namespace Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class DeleteSocialMediaCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteSocialMediaCommand(string id)
        {
            Id = id;
        }
    }
}
