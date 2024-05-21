using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class DeleteContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public DeleteContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteContactCommand deleteContactCommand)
        {
            var values = await _repository.GetAsync(deleteContactCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
