using MediatR;

namespace Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateAvailableToTrueCommand : IRequest
    {
        public string Id { get; set; }

        public UpdateAvailableToTrueCommand(string id)
        {
            Id = id;
        }
    }
}
