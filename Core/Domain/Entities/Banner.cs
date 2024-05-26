namespace Domain.Entities
{
    public class Banner
    {
        public string BannerID { get; } = Guid.NewGuid().ToString("D");
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
