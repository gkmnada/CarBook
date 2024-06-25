namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandByIdQuery
    {
        public string Id { get; set; }

        public GetCarWithBrandByIdQuery(string id)
        {
            Id = id;
        }
    }
}
