using TechTalk.SpecFlow;

namespace SpecFlowIntro.Tests.Steps
{
    [Binding]
    public class UbezpieczeniaSteps
    {
        [Given(@"istnienie następujących kientów")]
        public void ZakladajacIstnienieNastepujacychKientow(Table table)
        {
            //
        }

        [When(@"wyliczam balans dla portfela")]
        public void JezeliWyliczamBalansDlaPortfela()
        {
            //
        }

        [Then(@"balans wynosi (.*)")]
        public void WtedyBalansWynosi(int p0)
        {
            //
        }
    }
}