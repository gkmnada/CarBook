namespace Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult
    {
        public string CarID { get; set; }
        public string BrandID { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public int Kilometers { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImage { get; set; }
    }
}
