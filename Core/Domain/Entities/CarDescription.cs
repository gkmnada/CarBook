namespace Domain.Entities
{
    public class CarDescription
    {
        public string CarDescriptionID { get; } = Guid.NewGuid().ToString("D");
        public string CarID { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
    }
}
