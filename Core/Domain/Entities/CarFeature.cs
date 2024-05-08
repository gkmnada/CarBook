namespace Domain.Entities
{
    public class CarFeature
    {
        public Guid CarFeatureID { get; set; }
        public string CarID { get; set; }
        public Car Car { get; set; }
        public string FeatureID { get; set; }
        public Feature Feature { get; set; }
        public bool Available { get; set; }
    }
}
