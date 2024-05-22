using MediatR;

namespace Application.Features.Mediator.Commands.CarPricingCommands
{
    public class DeleteCarPricingCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteCarPricingCommand(string id)
        {
            Id = id;
        }
    }
}
