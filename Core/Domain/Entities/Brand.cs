namespace Domain.Entities
{
    public class Brand
    {
        public Guid BrandID { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
