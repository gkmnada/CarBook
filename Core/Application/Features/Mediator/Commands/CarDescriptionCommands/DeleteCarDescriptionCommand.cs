using MediatR;

namespace Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class DeleteCarDescriptionCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteCarDescriptionCommand(string id)
        {
            Id = id;
        }
    }
}
