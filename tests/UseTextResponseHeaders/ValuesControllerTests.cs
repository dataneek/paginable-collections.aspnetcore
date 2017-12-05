namespace PaginableCollections.AspNetCore
{
    using System;
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
        public async Task ShouldContainAllTextHeaders()
        {
            var result = await GetResult(1, 4);

            var pageNumberHeader = result.Headers
                .FirstOrDefault(t => t.Key == "X-Paginable-PageNumber")
                .Value.FirstOrDefault();

            var itemCountPerPageHeader = result.Headers
                .FirstOrDefault(t => t.Key == "X-Paginable-ItemCountPerPage")
                .Value.FirstOrDefault();

            var totalItemCountHeader = result.Headers
                .FirstOrDefault(t => t.Key == "X-Paginable-TotalItemCount")
                .Value.FirstOrDefault();

            var totalPageCountHeader = result.Headers
                .FirstOrDefault(t => t.Key == "X-Paginable-TotalPageCount")
                .Value.FirstOrDefault();

            Assert.True(pageNumberHeader == "1");
            Assert.True(itemCountPerPageHeader == "4");
            Assert.True(totalItemCountHeader == "20");
            Assert.True(totalPageCountHeader == "5");
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