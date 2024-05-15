using Application.Features.Mediator.Commands.ServiceCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ServiceHandlers;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public CreateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsnyc(new Service
        {
            Title = request.Title,
            Description = request.Description,
            Icon = request.Icon,
        });

        return Unit.Value;
    }
}
