namespace UnitTests.NamingSchemes
{
    using FluentAssertions;
    using Xunit;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class NamingSchemeBuilderUnitTests
    {
        [Fact]
        public void ShouldSetCustomPageNumberName()
        {
            const string name = "page-number";
            var sut = new NamingSchemeBuilder();

            sut.PageNumberNamed(name);

            sut.PageNumberName.ShouldBeEquivalentTo(name);
            sut.Build().PageNumberName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void ShouldSetCustomItemCountPerPageName()
        {
            const string name = "item-count-per-page";
            var sut = new NamingSchemeBuilder();

            sut.ItemCountPerPageNamed(name);

            sut.ItemCountPerPageName.ShouldBeEquivalentTo(name);
            sut.Build().ItemCountPerPageName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void ShouldSetCustomTotalItemCountPageName()
        {
            const string name = "total-item-count";
            var sut = new NamingSchemeBuilder();

            sut.TotalItemCountNamed(name);

            sut.TotalItemCountName.ShouldBeEquivalentTo(name);
            sut.Build().TotalItemCountName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void ShouldSetCustomTotalPageCountPageName()
        {
            const string name = "total-page-count";
            var sut = new NamingSchemeBuilder();

            sut.TotalPageCountNamed(name);

            sut.TotalPageCountName.ShouldBeEquivalentTo(name);
            sut.Build().TotalPageCountName.ShouldBeEquivalentTo(name);
        }
    }
}