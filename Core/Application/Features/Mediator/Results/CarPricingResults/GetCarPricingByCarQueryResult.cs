namespace Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingByCarQueryResult
    {
        public string CarPricingID { get; set; }
        public string CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string Period { get; set; }
    }
}
