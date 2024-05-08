namespace Domain.Entities
{
    public class Footer
    {
        public string FooterID { get; } = Guid.NewGuid().ToString("D");
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
