namespace Domain.Entities
{
    public class SocialMedia
    {
        public string SocialMediaID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
    }
}
