namespace Application.Features.CQRS.Commands.BrandCommands;

public class UpdateBrandCommand
{
    public string BrandID { get; set; }
    public string BrandName { get; set; }
}