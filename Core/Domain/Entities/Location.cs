namespace Domain.Entities
{
    public class Location
    {
        public string LocationID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public List<CarRental> CarRentals { get; set; }
        public List<Reservation> PickUpReservation { get; set; }
        public List<Reservation> DropOffReservation { get; set; }
    }
}
