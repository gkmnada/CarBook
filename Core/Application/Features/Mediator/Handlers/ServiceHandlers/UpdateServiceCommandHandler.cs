using Application.Features.Mediator.Commands.ServiceCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.ServiceID);

            values.Title = request.Title;
            values.Description = request.Description;
            values.Icon = request.Icon;

            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}