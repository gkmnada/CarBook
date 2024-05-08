namespace Domain.Entities
{
    public class Testimonial
    {
        public Guid TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
    }
}
