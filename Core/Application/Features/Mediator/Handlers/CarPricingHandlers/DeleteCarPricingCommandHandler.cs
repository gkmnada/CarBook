using Application.Features.Mediator.Commands.CarPricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class DeleteCarPricingCommandHandler : IRequestHandler<DeleteCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public DeleteCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCarPricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);
            await _repository.DeleteAsync(values);
            return Unit.Value;
        }
    }
}
