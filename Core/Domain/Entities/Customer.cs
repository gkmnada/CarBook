namespace Domain.Entities
{
    public class Customer
    {
        public string CustomerID { get; } = Guid.NewGuid().ToString("D");
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<RentalTransactions> RentalTransactions { get; set; }
    }
}
