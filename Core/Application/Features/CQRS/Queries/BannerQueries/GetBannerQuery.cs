namespace Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerQuery
    {
        public GetBannerQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
