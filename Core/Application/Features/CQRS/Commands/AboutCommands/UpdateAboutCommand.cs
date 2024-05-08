namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateAboutCommand
    {
        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
