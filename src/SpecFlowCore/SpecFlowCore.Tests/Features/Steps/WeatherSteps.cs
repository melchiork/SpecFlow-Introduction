using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SpecFlowCore.Api;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowCore.Tests.Features.Steps
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

        [When(@"I ask for certainty in '(.*)' days")]
        public async Task WhenIAskForCertaintyInDays(int days)
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var client = server.CreateClient();

            var response = await client.GetAsync($"WeatherForecast/certainty?days={days}");

            var result = await response.Content.ReadFromJsonAsync<decimal>();

            _context.Set(result, "certainty");

        }

        [Then(@"the certainty is '(.*)'%")]
        public void ThenTheCertaintyIs(decimal expectedCertainty)
        {
            var certainty = _context.Get<decimal>("certainty");

            certainty.Should().Be(expectedCertainty);
        }

    }
}