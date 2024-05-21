namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class DeleteContactCommand
    {
        public string Id { get; set; }

        public DeleteContactCommand(string id)
        {
            Id = id;
        }
    }
}
