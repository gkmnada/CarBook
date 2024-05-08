namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class DeleteBannerCommand
    {
        public DeleteBannerCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
