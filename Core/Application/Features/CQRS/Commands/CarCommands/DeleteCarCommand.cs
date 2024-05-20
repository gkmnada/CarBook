namespace Application.Features.CQRS.Commands.CarCommands
{
    public class DeleteCarCommand
    {
        public string Id { get; set; }

        public DeleteCarCommand(string id)
        {
            Id = id;
        }
    }
}
