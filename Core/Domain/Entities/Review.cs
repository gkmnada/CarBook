namespace Domain.Entities
{
    public class Review
    {
        public string ReviewID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CarID { get; set; }
        public Car Car { get; set; }
    }
}
