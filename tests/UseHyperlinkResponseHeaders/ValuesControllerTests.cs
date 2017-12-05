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
        public async Task ShouldNotContainPaginableHeader()
        {
            var result = await GetResult(1, 5);

            var header = result.Headers.FirstOrDefault(t => t.Key == "X-Paginable");
            var value = header.Value;

            Assert.True(value == null);
        }

        [Fact]
        public async Task ShouldContainLinkHeader()
        {
            var result = await GetResult(1, 5);

            var header = result.Headers.FirstOrDefault(t => t.Key == "Link");
            var value = header.Value;

            Assert.True(value != null);
        }

        [Fact]
        public async Task ShouldContainFirstLinkHeader()
        {
            var result = await GetResult(4, 3);

            LinkParser linkParser = new LinkParser(result);

            Assert.True(!string.IsNullOrEmpty(linkParser.First));
        }

        [Fact]
        public async Task ShouldContainPreviousLinkHeader()
        {
            var result = await GetResult(3, 4);

            LinkParser linkParser = new LinkParser(result);

            Assert.True(!string.IsNullOrEmpty(linkParser.Previous));
        }

        [Fact]
        public async Task ShouldContainCurrentLinkHeader()
        {
            var result = await GetResult(1, 22);

            LinkParser linkParser = new LinkParser(result);

            Assert.True(!string.IsNullOrEmpty(linkParser.Current));
        }

        [Fact]
        public async Task ShouldContainNextLinkHeader()
        {
            var result = await GetResult(1, 3);

            LinkParser linkParser = new LinkParser(result);

            Assert.True(!string.IsNullOrEmpty(linkParser.Next));
        }

        [Fact]
        public async Task ShouldContainLastLinkHeader()
        {
            var result = await GetResult(1, 3);

            LinkParser linkParser = new LinkParser(result);

            Assert.True(!string.IsNullOrEmpty(linkParser.Last));
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