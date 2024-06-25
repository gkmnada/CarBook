using MediatR;

namespace Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class UpdateCarDescriptionCommand : IRequest
    {
        public string CarDescriptionID { get; set; }
        public string CarID { get; set; }
        public string Description { get; set; }
    }
}
