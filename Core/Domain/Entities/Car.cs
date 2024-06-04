namespace Domain.Entities
{
    public class Car
    {
        public string CarID { get; } = Guid.NewGuid().ToString("D");
        public string BrandID { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public int Kilometers { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImage { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<CarRental> CarRentals { get; set; }
        public List<RentalTransactions> RentalTransactions { get; set; }
    }
}
