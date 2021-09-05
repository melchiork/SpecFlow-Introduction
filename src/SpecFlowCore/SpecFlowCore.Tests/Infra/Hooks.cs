using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SpecFlowCore.Api;
using TechTalk.SpecFlow;

namespace SpecFlowCore.Tests.Infra
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public static void CreateTestServer(ScenarioContext scenarioContext)
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var client = server.CreateClient();

            scenarioContext.Set(server, "server");
            scenarioContext.Set(client, "client");
        }
    }
}
