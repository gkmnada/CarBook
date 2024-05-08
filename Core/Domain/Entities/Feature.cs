namespace Domain.Entities
{
    public class Feature
    {
        public string FeatureID { get; } = Guid.NewGuid().ToString("D");
        public string FeatureName { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
