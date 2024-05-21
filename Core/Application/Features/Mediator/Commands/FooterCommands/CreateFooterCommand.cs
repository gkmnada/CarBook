using MediatR;

namespace Application.Features.Mediator.Commands.FooterCommands
{
    public class CreateFooterCommand : IRequest
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
