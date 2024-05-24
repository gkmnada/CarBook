using MediatR;

namespace Application.Features.Mediator.Commands.LocationCommands
{
    public class DeleteLocationCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteLocationCommand(string id)
        {
            Id = id;
        }
    }
}
