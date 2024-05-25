using MediatR;

namespace Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public string SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
    }
}
