namespace Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByIdQueryResult
    {
        public string ReviewID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CarID { get; set; }
    }
}
