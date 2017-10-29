namespace PaginableCollections.AspNetCore.IntegrationTests.LinkBased
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Xunit;

    public class ValuesControllerTests
    {
        private readonly TestServer testServer;
        private readonly HttpClient httpClient;

        public ValuesControllerTests()
        {
            testServer =
                new TestServer(
                    new WebHostBuilder().UseStartup<Startup>());

            httpClient = testServer.CreateClient();
        }

        private async Task<HttpResponseMessage> GetResult(int pageNumber, int itemCountPerPage)
        {
            var request = $"/api/values/{pageNumber}/{itemCountPerPage}";
            var response = await httpClient.GetAsync(request);

            return response;
        }

        [Fact]
        public async Task ShouldDoSomething()
        {
            var result = await GetResult(1, 5);
            var content = await result.Content.ReadAsStringAsync();

            var header = result.Headers.FirstOrDefault(t => t.Key == "X-Paginable");
            var value = header.Value;

            Assert.True(value != null);
        }
    }
}