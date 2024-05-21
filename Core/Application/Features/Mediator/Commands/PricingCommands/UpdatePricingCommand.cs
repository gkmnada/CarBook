using MediatR;

namespace Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand : IRequest
    {
        public string PricingID { get; set; }
        public string Name { get; set; }
    }
}
