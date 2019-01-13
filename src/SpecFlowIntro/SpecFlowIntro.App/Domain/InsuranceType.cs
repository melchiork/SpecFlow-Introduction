namespace SpecFlowIntro.App.Domain
{
    public class InsuranceType
    {
        public InsuranceType(string name, string applicableTo = "All")
        {
            Name = name;
            ApplicableTo = applicableTo;
        }

        public string Name { get; }

        public string ApplicableTo { get; }
    }
}