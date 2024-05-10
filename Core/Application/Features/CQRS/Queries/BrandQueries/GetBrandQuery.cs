namespace Application.Features.CQRS.Queries.BrandQueries;

public class GetBrandQuery
{
    public GetBrandQuery(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}