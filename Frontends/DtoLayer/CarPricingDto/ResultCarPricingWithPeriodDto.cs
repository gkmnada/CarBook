namespace DtoLayer.CarPricingDto
{
    public class ResultCarPricingWithPeriodDto
    {
        public string CarID { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
