using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SpatialQuery.WebAPI.IntegrationTests
{
	public class DistancesControllerIntegrationTests
	{
		[Fact]
		public async Task HappyPathWorks()
		{
			// Arrange
			TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
			HttpClient client = server.CreateClient();

			string requestUri =
				"SpatialQuery/Distances/GeographicalBetweenTwoPoints?"
				+ "originLatitude=40.7486"
				+ "&originLongitude=-73.9864"
				+ "&destinationLatitude=24.7486"
				+ "&destinationLongitude=-72.9864"
				+ "&approach=Haversine"
				+ "&outputUnit=Kilometer";

			// Act
			var response = await client.GetAsync(requestUri);
			response.EnsureSuccessStatusCode();
			string actual = await response.Content.ReadAsStringAsync();

			// Assert
			Assert.Equal("{\"length\":1783.5357397059595,\"unit\":\"Kilometer\"}", actual);
		}
	}
}
