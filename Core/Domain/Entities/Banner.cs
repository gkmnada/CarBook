namespace Domain.Entities
{
    public class Banner
    {
        public Guid BannerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string Video { get; set; }
    }
}
