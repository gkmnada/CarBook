using MediatR;

namespace Application.Features.Mediator.Commands.ServiceCommands
{
    public class CreateServiceCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
