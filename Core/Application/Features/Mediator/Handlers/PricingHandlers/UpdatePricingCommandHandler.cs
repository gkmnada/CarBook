using Application.Features.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.PricingID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
