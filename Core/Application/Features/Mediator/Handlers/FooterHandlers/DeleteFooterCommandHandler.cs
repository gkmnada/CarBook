using Application.Features.Mediator.Commands.FooterCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterHandlers
{
    public class DeleteFooterCommandHandler : IRequestHandler<DeleteFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public DeleteFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);
            await _repository.DeleteAsync(values);

            return Unit.Value;
        }
    }
}
