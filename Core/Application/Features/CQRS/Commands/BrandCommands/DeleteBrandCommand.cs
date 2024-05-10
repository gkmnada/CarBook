namespace Application.Features.CQRS.Commands.BrandCommands;

public class DeleteBrandCommand
{
    public DeleteBrandCommand(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}