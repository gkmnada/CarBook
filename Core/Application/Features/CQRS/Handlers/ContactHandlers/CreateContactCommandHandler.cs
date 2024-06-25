using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand createContactCommand)
        {
            await _repository.CreateAsync(new Contact
            {
                Name = createContactCommand.Name,
                Email = createContactCommand.Email,
                Subject = createContactCommand.Subject,
                Message = createContactCommand.Message,
                CreatedAt = DateTime.Now
            });
        }
    }
}
