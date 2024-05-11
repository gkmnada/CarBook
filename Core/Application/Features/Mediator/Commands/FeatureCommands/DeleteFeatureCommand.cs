using MediatR;

namespace Application.Features.Mediator.Commands.FeatureCommands
{
    public class DeleteFeatureCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteFeatureCommand(string id)
        {
            Id = id;
        }
    }
}
