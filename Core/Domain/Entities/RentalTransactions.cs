namespace Domain.Entities
{
    public class RentalTransactions
    {
        public string RentalTransactionsID { get; } = Guid.NewGuid().ToString("D");
        public string CarID { get; set; }
        public Car Car { get; set; }
        public string PickUpLocationID { get; set; }
        public string DropOffLocationID { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DropOffDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public TimeOnly DropOffTime { get; set; }
        public string CustomerID { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
