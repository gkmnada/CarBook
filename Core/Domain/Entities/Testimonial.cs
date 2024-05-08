namespace Domain.Entities
{
    public class Testimonial
    {
        public string TestimonialID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
    }
}
