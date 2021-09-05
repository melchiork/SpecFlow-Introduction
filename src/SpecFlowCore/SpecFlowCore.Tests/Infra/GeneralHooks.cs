using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace SpecFlowCore.Tests.Infra
{
    [Binding]
    public class GeneralHooks
    {
        private readonly ITestOutputHelper output;

        public GeneralHooks(ITestOutputHelper output)
        {
            this.output = output;
        }

        [AfterScenario]
        public void Bye()
        {
            //output.WriteLine("Kthx, bye!");
        }
    }
}
