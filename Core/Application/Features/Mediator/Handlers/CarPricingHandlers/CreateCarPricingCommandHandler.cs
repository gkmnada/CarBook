using Application.Features.Mediator.Commands.CarPricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public CreateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarPricing
            {
                CarID = request.CarID,
                PricingID = request.PricingID,
                Amount = request.Amount
            });

            return Unit.Value;
        }
    }
}
