using MediatR;

namespace Application.Features.Mediator.Commands.ServiceCommands
{
    public class DeleteServiceCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteServiceCommand(string id)
        {
            Id = id;
        }
    }
}
