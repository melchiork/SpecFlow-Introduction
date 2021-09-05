using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SpecFlowCore.Api;
using TechTalk.SpecFlow;

namespace SpecFlowCore.Tests.Infra
{
    [Binding]
    public class ServerHooks
    {
        //TODO: Does this need to be run for every - even non-web api - tests?
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
