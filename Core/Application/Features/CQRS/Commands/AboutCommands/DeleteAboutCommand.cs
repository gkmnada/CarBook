namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class DeleteAboutCommand
    {
        public DeleteAboutCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
