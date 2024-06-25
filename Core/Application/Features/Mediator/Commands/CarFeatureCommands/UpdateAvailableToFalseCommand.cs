using MediatR;

namespace Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateAvailableToFalseCommand : IRequest
    {
        public string Id { get; set; }

        public UpdateAvailableToFalseCommand(string id)
        {
            Id = id;
        }
    }
}
