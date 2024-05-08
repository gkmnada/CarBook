namespace Domain.Entities
{
    public class Brand
    {
        public string BrandID { get; } = Guid.NewGuid().ToString("D");
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
