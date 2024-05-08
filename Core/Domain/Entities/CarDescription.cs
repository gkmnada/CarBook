namespace Domain.Entities
{
    public class CarDescription
    {
        public Guid CarDescriptionID { get; set; }
        public Guid CarID { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
    }
}
