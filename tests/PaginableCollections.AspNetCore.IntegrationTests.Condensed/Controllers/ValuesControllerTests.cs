namespace PaginableCollections.AspNetCore.IntegrationTests.Condensed
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Newtonsoft.Json;
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
        public async Task ShouldContainAllCondensedHeaders()
        {
            var result = await GetResult(1, 4);

            var definition = new { PageNumber = "", ItemCountPerPage = "", TotalItemCount = "", TotalPageCount = "" };

            var paginationJson = result.Headers
                .FirstOrDefault(t => t.Key == "X-Paginable")
                .Value.FirstOrDefault();

            var pagination = JsonConvert.DeserializeAnonymousType(paginationJson, definition);

            Assert.True(pagination.PageNumber == "1");
            Assert.True(pagination.ItemCountPerPage == "4");
            Assert.True(pagination.TotalItemCount == "20");
            Assert.True(pagination.TotalPageCount == "5");
        }

        [Fact]
        public async Task ShouldFailOnZeroPageNumber()
        {
            var exception = await Record.ExceptionAsync(async () => await GetResult(0, 5));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        [Fact]
        public async Task ShouldFailOnZeroItemCount()
        {
            var exception = await Record.ExceptionAsync(async () => await GetResult(1, 0));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        [Fact]
        public async Task ShouldFailOnZeroPageNumberAndZeroItemCount()
        {
            var exception = await Record.ExceptionAsync(async () => await GetResult(0, 0));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }
    }
}