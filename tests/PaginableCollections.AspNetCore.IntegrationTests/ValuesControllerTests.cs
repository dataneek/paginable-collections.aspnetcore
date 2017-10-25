namespace PaginableCollections.AspNetCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;
    using Microsoft.AspNetCore.TestHost;
    using System.Net.Http;
    using Microsoft.AspNetCore.Hosting;


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
        }
    }
}