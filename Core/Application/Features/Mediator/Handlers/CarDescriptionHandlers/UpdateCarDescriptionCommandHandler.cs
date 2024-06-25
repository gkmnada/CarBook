using Application.Features.Mediator.Commands.CarDescriptionCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public UpdateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.CarDescriptionID);
            values.CarID = request.CarID;
            values.Description = request.Description;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
