namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public string Id { get; set; }

        public GetCarByIdQuery(string id)
        {
            Id = id;
        }
    }
}
