namespace Domain.Entities
{
    public class Reservation
    {
        public string ReservationID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CarID { get; set; }
        public Car Car { get; set; }
        public string? PickUpLocationID { get; set; }
        public string? DropOffLocationID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
