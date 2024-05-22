using MediatR;

namespace Application.Features.Mediator.Commands.CarPricingCommands
{
    public class CreateCarPricingCommand : IRequest
    {
        public string CarID { get; set; }
        public string PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
