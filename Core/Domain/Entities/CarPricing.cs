namespace Domain.Entities
{
    public class CarPricing
    {
        public Guid CarPricingID { get; set; }
        public Guid CarID { get; set; }
        public Car Car { get; set; }
        public Guid PricingID { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
