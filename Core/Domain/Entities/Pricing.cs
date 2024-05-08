namespace Domain.Entities
{
    public class Pricing
    {
        public Guid PricingID { get; set; }
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
