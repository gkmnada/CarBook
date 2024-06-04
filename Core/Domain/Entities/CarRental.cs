namespace Domain.Entities
{
    public class CarRental
    {
        public string CarRentalID { get; } = Guid.NewGuid().ToString("D");
        public string LocationID { get; set; }
        public Location Location { get; set; }
        public string CarID { get; set; }
        public Car Car { get; set; }
        public bool Available { get; set; }
    }
}
