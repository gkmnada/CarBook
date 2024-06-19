namespace DtoLayer.ReservationDto
{
    public class CreateReservationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CarID { get; set; }
        public string PickUpLocationID { get; set; }
        public string DropOffLocationID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
    }
}
