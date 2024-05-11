using MediatR;

namespace Application.Features.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public string FeatureID { get; set; }
        public string FeatureName { get; set; }
    }
}
