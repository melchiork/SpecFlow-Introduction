using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SpecFlow.Internal.Json;
using SpecFlowCore.Api;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowCore.Tests.Integration.Steps
{
    [Binding]
    public class WeatherSteps
    {
        private readonly ScenarioContext _context;

        public WeatherSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the location is '(.*)'")]
        public void GivenTheLocationIs(string location)
        {
            _context.Set(location, "currentLocation");
        }

        [When(@"I ask for the weather")]
        public async Task WhenIAskForTheWeather()
        {
            var currentLocation = _context.Get<string>("currentLocation");

            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var client = server.CreateClient();
            var response = await client.GetAsync($"WeatherForecast?location={currentLocation}");
            var result = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();

            _context.Set(result, "weatherForecasts");
        }

        [Then(@"the result should be as follows")]
        public void ThenTheResultShouldBeAsFollows(Table table)
        {
            var forecasts = _context.Get<WeatherForecast[]>("weatherForecasts");

            table.CompareToSet(forecasts);
        }

    }
}