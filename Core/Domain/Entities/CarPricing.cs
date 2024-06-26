﻿namespace Domain.Entities
{
    public class CarPricing
    {
        public string CarPricingID { get; } = Guid.NewGuid().ToString("D");
        public string CarID { get; set; }
        public Car Car { get; set; }
        public string PricingID { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
