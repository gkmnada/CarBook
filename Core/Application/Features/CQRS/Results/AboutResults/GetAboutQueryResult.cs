namespace Application.Features.CQRS.Results.AboutResults
{
    public class GetAboutQueryResult
    {
        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
