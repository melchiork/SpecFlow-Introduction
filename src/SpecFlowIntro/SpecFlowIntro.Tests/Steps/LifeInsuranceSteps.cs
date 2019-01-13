using System.Collections.Generic;
using FluentAssertions;
using SpecFlowIntro.App.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowIntro.Tests.Steps
{
    [Binding]
    public class LifeInsuranceSteps
    {
        private readonly BasicContext _basicContext;

        private readonly ScenarioContext _scenarioContext;

        public LifeInsuranceSteps(BasicContext basicContext, ScenarioContext scenarioContext)
        {
            _basicContext = basicContext;
            _scenarioContext = scenarioContext;
        }

        [Given(@"following life expectancies exist")]
        public void GivenFollowingLifeExpectanciesExist(Table table)
        {
            var lifeExpectancies = table.CreateSet<LifeExpectancy>();

            _basicContext.Config.LifeExpectancies = lifeExpectancies;
        }

        [Given(@"following health rate expectancies exist")]
        public void GivenFollowingHealthRateExpectanciesExist(Table table)
        {
        }

        [When(@"I submit following request for life insurance")]
        public void WhenISubmitFollowingRequestForLifeInsurance(Table table)
        {
            var request = table.CreateInstance<LifeInsuranceRequest>();

            var rates = _basicContext.Facade.GetLifeInsuranceRates(request);

            _scenarioContext.Set(rates, "LifeInsuranceRates");
        }

        [Then(@"the life insurance calculation is as follows")]
        public void ThenTheLifeInsuranceCalculationIsAsFollows(Table table)
        {
            var rates = _scenarioContext.Get<IEnumerable<InsuranceRate>>("LifeInsuranceRates");

            table.CompareToSet(rates);
        }

        [When(@"I ask for discount for rate (.*) for client (.*)")]
        public void WhenIAskForDiscountForRateForClient(string rateName, string clientName)
        {
            var discount = _basicContext.Facade.GetDiscount(rateName, clientName);

            _scenarioContext.Set(discount);
        }

        [Then(@"discount of (.*)% is returned")]
        public void ThenDiscountOfIsReturned(int expectedDiscountValue)
        {
            var discount = _scenarioContext.Get<Discount>();

            discount.PercentageValue.Should().Be(expectedDiscountValue);
        }
    }
}