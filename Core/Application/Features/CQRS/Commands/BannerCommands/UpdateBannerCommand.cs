namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommand
    {
        public string BannerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string Video { get; set; }
    }
}
