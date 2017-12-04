namespace UnitTests
{
    using FluentAssertions;
    using Xunit;
    using PaginableCollections.AspNetCore;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class LinkHeaderFormatOptionsBuilderUnitTests
    {
        [Fact]
        public void ShouldHaveHeaderFormatOptions()
        {
            var options = new HeaderFormatOptions();
            var sut = new LinkHeaderFormatOptionsBuilder(options);

            sut.Options.Should().NotBeNull();
        }

        [Fact]
        public void ShouldHaveFilterType()
        {
            var options = new HeaderFormatOptions();
            var sut = new LinkHeaderFormatOptionsBuilder(options);

            sut.Options.FilterType.ShouldBeEquivalentTo(typeof(UseLinkPaginationHeadersActionFilter));
        }

        [Fact]
        public void ShouldNotHaveNamingScheme()
        {
            var options = new HeaderFormatOptions();
            var sut = new LinkHeaderFormatOptionsBuilder(options);

            sut.Options.NamingScheme.Should().BeNull();
        }
    }
}