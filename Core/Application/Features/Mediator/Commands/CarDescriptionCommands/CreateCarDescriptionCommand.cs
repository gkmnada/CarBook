using MediatR;

namespace Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand : IRequest
    {
        public string CarID { get; set; }
        public string Description { get; set; }
    }
}
