using System;
using System.Collections.Generic;
using System.Linq;
using SpecFlowIntro.App.Domain;

namespace SpecFlowIntro.App
{
    public class Facade
    {
        private const int LifeInsuranceMultiplier = 132;

        private Facade()
        {
        }

        public static Facade Instance => new Facade();

        public IEnumerable<InsuranceType> GetInsuranceTypes()
        {
            yield return new InsuranceType("Mortgage");
            yield return new InsuranceType("Life", "Individual");
            yield return new InsuranceType("Property");
            yield return new InsuranceType("Health", "Individual");
        }

        public IEnumerable<InsuranceRate> GetLifeInsuranceRates(LifeInsuranceRequest request)
        {
            var expectancy = Config.Instance.LifeExpectancies.Single(x => x.Gender == request.Gender);
            var basicYearlyRate = (expectancy.ExpectedLifespan - request.Age) / (double) expectancy.ExpectedLifespan *
                                  LifeInsuranceMultiplier;

            var rates = new List<InsuranceRate>
            {
                new InsuranceRate("Premium", (int) basicYearlyRate + 150),
                new InsuranceRate("Standard", (int) basicYearlyRate)
            };

            return rates.Where(x => x.Name == request.Rate || string.IsNullOrEmpty(request.Rate));
        }

        public Discount GetDiscount(string rateName, string clientName)
        {
            return clientName.Equals("Bob")
                ? new Discount(15, DateTime.Now.AddDays(10))
                : new Discount(8, DateTime.Now.AddDays(1));
        }
    }
}