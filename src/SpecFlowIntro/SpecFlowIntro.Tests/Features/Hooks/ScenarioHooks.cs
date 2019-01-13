using System;
using System.Transactions;
using TechTalk.SpecFlow;

namespace SpecFlowIntro.Tests.Features.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("InTransaction")]
        public void StartTransaction()
        {
            var scope = new TransactionScope(TransactionScopeOption.RequiresNew);

            Console.WriteLine("Starting new transaction.");
            _scenarioContext.Set(scope);
        }

        [AfterScenario("InTransaction")]
        public void DiscardTransaction()
        {
            var transactionScope = _scenarioContext.Get<TransactionScope>();
            transactionScope.Dispose();
            Console.WriteLine("Transaction discarded.");
        }
    }
}
