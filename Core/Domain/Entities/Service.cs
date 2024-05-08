namespace Domain.Entities
{
    public class Service
    {
        public string ServiceID { get; } = Guid.NewGuid().ToString("D");
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
