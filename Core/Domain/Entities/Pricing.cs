namespace Domain.Entities
{
    public class Pricing
    {
        public string PricingID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
