using Application.Features.Mediator.Commands.CarPricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.CarPricingID);

            values.CarID = request.CarID;
            values.PricingID = request.PricingID;
            values.Amount = request.Amount;

            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
