using MediatR;

namespace Application.Features.Mediator.Commands.PricingCommands
{
    public class DeletePricingCommand : IRequest
    {
        public string Id { get; set; }

        public DeletePricingCommand(string id)
        {
            Id = id;
        }
    }
}
