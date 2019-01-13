using System;

namespace SpecFlowIntro.App.Domain
{
    public class InsuranceRate
    {
        public InsuranceRate(string rateName, decimal yearlyRate)
        {
            Name = rateName;
            Yearly = yearlyRate;
            Monthly = Math.Round(yearlyRate / 12 * Config.Instance.MonthlyFactor, 2);
        }

        public string Name { get; }
        public decimal Yearly { get; }
        public decimal Monthly { get; }
    }
}