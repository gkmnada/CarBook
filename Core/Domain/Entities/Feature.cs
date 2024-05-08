namespace Domain.Entities
{
    public class Feature
    {
        public Guid FeatureID { get; set; }
        public string FeatureName { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
