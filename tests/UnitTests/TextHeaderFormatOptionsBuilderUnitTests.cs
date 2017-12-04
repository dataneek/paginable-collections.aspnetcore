namespace UnitTests
{
    using FluentAssertions;
    using Xunit;
    using PaginableCollections.AspNetCore;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class TextHeaderFormatOptionsBuilderUnitTests
    {
        [Fact]
        public void ShouldHaveHeaderFormatOptions()
        {
            var options = new HeaderFormatOptions();
            var sut = new TextHeaderFormatOptionsBuilder(options);

            sut.Options.Should().NotBeNull();
        }

        [Fact]
        public void ShouldHaveFilterType()
        {
            var options = new HeaderFormatOptions();
            var sut = new TextHeaderFormatOptionsBuilder(options);

            sut.Options.FilterType.ShouldBeEquivalentTo(typeof(UseTextPaginationResponseHeadersActionFilter));
        }


        [Fact]
        public void ShouldHaveNamingScheme()
        {
            var options = new HeaderFormatOptions();
            var sut = new TextHeaderFormatOptionsBuilder(options);

            sut.Options.NamingScheme.Should().NotBeNull();
        }

        [Fact]
        public void ShouldHaveDefaultNamingScheme()
        {
            var options = new HeaderFormatOptions();
            var sut = new TextHeaderFormatOptionsBuilder(options);

            sut.Options.NamingScheme.ShouldBeEquivalentTo(NamingScheme.Default);
        }
    }
}