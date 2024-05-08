namespace Domain.Entities
{
    public class CarFeature
    {
        public Guid CarFeatureID { get; set; }
        public Guid CarID { get; set; }
        public Car Car { get; set; }
        public Guid FeatureID { get; set; }
        public Feature Feature { get; set; }
        public bool Available { get; set; }
    }
}
