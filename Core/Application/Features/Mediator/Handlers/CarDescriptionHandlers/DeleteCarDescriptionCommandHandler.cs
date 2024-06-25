using Application.Features.Mediator.Commands.CarDescriptionCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class DeleteCarDescriptionCommandHandler : IRequestHandler<DeleteCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;

        public DeleteCarDescriptionCommandHandler(IRepository<CarDescription> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);
            await _repository.DeleteAsync(values);
            return Unit.Value;
        }
    }
}
