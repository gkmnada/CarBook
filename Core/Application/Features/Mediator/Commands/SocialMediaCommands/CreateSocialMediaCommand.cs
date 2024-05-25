using MediatR;

namespace Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
    }
}
