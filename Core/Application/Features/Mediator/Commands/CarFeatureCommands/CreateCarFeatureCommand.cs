using MediatR;

namespace Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureCommand : IRequest
    {
        public string CarID { get; set; }
        public string FeatureID { get; set; }
    }
}
