namespace UnitTests
{
    using FluentAssertions;
    using Xunit;
    using PaginableCollections.AspNetCore;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class JsonHeaderFormatOptionsBuilderUnitTests
    {
        [Fact]
        public void ShouldHaveHeaderFormatOptions()
        {
            var options = new HeaderFormatOptions();
            var sut = new JsonHeaderFormatOptionsBuilder(options);

            sut.Options.Should().NotBeNull();
        }

        [Fact]
        public void ShouldHaveFilterType()
        {
            var options = new HeaderFormatOptions();
            var sut = new JsonHeaderFormatOptionsBuilder(options);

            sut.Options.FilterType.ShouldBeEquivalentTo(typeof(UseJsonPaginationResponseHeadersActionFilter));
        }

        //[Fact]
        //public void ShouldHaveNamingScheme()
        //{
        //    var options = new HeaderFormatOptions();
        //    var sut = new JsonHeaderFormatOptionsBuilder(options);

        //    sut.Options.NamingScheme.Should().NotBeNull();
        //}

        //[Fact]
        //public void ShouldHaveDefaultNamingScheme()
        //{
        //    var options = new HeaderFormatOptions();
        //    var sut = new JsonHeaderFormatOptionsBuilder(options);

        //    sut.Options.NamingScheme.ShouldBeEquivalentTo(NamingScheme.Default);
        //}
    }
}