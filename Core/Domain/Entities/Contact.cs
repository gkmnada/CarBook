namespace Domain.Entities
{
    public class Contact
    {
        public string ContactID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
