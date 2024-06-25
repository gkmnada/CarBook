using Application.Features.Mediator.Commands.FooterCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterHandlers
{
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public CreateFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Footer
            {
                Description = request.Description,
                Address = request.Address,
                Email = request.Email,
                Phone = request.Phone,
            });

            return Unit.Value;
        }
    }
}
