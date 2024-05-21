namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class DeleteCategoryCommand
    {
        public string Id { get; set; }

        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
    }
}
