namespace Domain.Entities
{
    public class Category
    {
        public string CategoryID { get; } = Guid.NewGuid().ToString("D");
        public string CategoryName { get; set; }
    }
}
