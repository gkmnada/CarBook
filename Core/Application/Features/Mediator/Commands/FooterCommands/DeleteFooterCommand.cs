using MediatR;

namespace Application.Features.Mediator.Commands.FooterCommands
{
    public class DeleteFooterCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteFooterCommand(string id)
        {
            Id = id;
        }
    }
}
