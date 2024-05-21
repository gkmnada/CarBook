using Application.Features.Mediator.Commands.FooterCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FooterHandlers
{
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public UpdateFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.FooterID);

            values.Description = request.Description;
            values.Address = request.Address;
            values.Email = request.Email;
            values.Phone = request.Phone;

            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
