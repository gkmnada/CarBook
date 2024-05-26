namespace Application.Features.CQRS.Results.BannerResults
{
    public class GetBannerQueryResult
    {
        public string BannerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
