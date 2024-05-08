namespace Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutQuery
    {
        public GetAboutQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
