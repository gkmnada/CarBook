namespace Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationByIdQueryResult
    {
        public string ReservationID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CarID { get; set; }
        public string PickUpLocationID { get; set; }
        public string DropOffLocationID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
