namespace Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery
    {
        public string Id { get; set; }

        public GetBannerByIdQuery(string id)
        {
            Id = id;
        }
    }
}
