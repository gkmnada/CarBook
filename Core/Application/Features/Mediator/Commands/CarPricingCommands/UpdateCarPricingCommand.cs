using MediatR;

namespace Application.Features.Mediator.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand : IRequest
    {
        public string CarPricingID { get; set; }
        public string CarID { get; set; }
        public string PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
