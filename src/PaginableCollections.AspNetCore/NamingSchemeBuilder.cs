namespace PaginableCollections.AspNetCore
{
    public class NamingSchemeBuilder : INamingSchemeBuilder
    {
        public string TotalItemCountName { get; private set; }
        public string TotalPageCountName { get; private set; }
        public string PageNumberName { get; private set; }
        public string ItemCountPerPageName { get; private set; }

        public INamingScheme Build()
        {
            return new NamingScheme(
                PageNumberName ?? NamingScheme.Default.PageNumberName,
                ItemCountPerPageName ?? NamingScheme.Default.ItemCountPerPageName,
                TotalItemCountName ?? NamingScheme.Default.TotalItemCountName,
                TotalPageCountName ?? NamingScheme.Default.TotalPageCountName);
        }

        public INamingSchemeBuilder ItemCountPerPageNamed(string itemCountPerPageName)
        {
            this.ItemCountPerPageName = itemCountPerPageName;
            return this;
        }

        public INamingSchemeBuilder PageNumberNamed(string pageNumberName)
        {
            PageNumberName = pageNumberName;
            return this;
        }

        public INamingSchemeBuilder TotalItemCountNamed(string totalItemCountName)
        {
            TotalItemCountName = totalItemCountName;
            return this;
        }

        public INamingSchemeBuilder TotalPageCountNamed(string totalPageCountName)
        {
            TotalPageCountName = totalPageCountName;
            return this;
        }
    }
}