namespace UnitTests.NamingSchemes
{
    using FluentAssertions;
    using Xunit;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class NamingSchemeUnitTests
    {
        [Fact]
        public void ShouldSetCustomPageNumberName()
        {
            const string name = "page-number";
            var sut = new NamingScheme(name, "b", "c", "d");

            sut.PageNumberName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void ShouldSetCustomItemCountPerPageName()
        {
            const string name = "item-count-per-page";
            var sut = new NamingScheme("a", name, "c", "d");

            sut.ItemCountPerPageName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void ShouldSetCustomTotalItemCountPageName()
        {
            const string name = "total-item-count";
            var sut = new NamingScheme("a", "b", name, "d");

            sut.TotalItemCountName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void ShouldSetCustomTotalPageCountPageName()
        {
            const string name = "total-page-count";
            var sut = new NamingScheme("a", "b", "c", name);

            sut.TotalPageCountName.ShouldBeEquivalentTo(name);
        }
    }
}