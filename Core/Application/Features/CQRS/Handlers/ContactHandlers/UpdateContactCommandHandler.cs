using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand updateContactCommand)
        {
            var values = await _repository.GetAsync(updateContactCommand.ContactID);

            values.Name = updateContactCommand.Name;
            values.Email = updateContactCommand.Email;
            values.Subject = updateContactCommand.Subject;
            values.Message = updateContactCommand.Message;
            values.CreatedAt = DateTime.Now;

            await _repository.UpdateAsync(values);
        }
    }
}
