using System.Collections.Generic;
using System.Linq;
using SpecFlowIntro.App.Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowIntro.Tests.Steps
{
    [Binding]
    public class BasicsSteps
    {
        private readonly BasicContext _basicContext;

        public BasicsSteps(BasicContext basicContext)
        {
            _basicContext = basicContext;
        }

        [Given(@"I am logged in as (.*)")]
        public void GivenIJohn(string name)
        {
            //security comes next
        }

        [When(@"I list all insurance types")]
        public void WhenIListAllInsuranceTypes()
        {
            var insuranceTypes = _basicContext.Facade.GetInsuranceTypes().ToList();

            ScenarioContext.Current.Set(insuranceTypes);
        }

        [Then(@"insurance types are as follows")]
        public void ThenInsuranceTypesAreAsFollows(Table table)
        {
            var insuranceTypes = ScenarioContext.Current.Get<List<InsuranceType>>();

            table.CompareToSet(insuranceTypes);
        }

        [When(@"I list all insurance claims for client (.*)")]
        public void WhenIListAllInsuranceClaimsForClient(string clientName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"insurance claims are as follows")]
        public void ThenInsuranceClaimsAreAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}