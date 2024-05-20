namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class DeleteBrandCommand
    {
        public string Id { get; set; }

        public DeleteBrandCommand(string id)
        {
            Id = id;
        }
    }
}
