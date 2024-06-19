namespace Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarRentalQueryResult
    {
        public string CarID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string Image { get; set; }
    }
}
