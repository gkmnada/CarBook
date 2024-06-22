namespace DtoLayer.CarPricingDto
{
    public class UpdateCarPricingDto
    {
        public string CarPricingID { get; set; }
        public string CarID { get; set; }
        public string PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
