namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery
    {
        public string Id { get; set; }

        public GetBrandByIdQuery(string id)
        {
            Id = id;
        }
    }
}
