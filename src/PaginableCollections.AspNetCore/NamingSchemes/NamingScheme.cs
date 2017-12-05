namespace PaginableCollections.AspNetCore.NamingSchemes
{
    public class NamingScheme : INamingScheme
    {
        const string DefaultHeaderKeyName = "X-Paginable";

        const string DefaultPageNumberName = "PageNumber";
        const string DefaultItemCountPerPageName = "ItemCountPerPage";
        const string DefaultTotalItemCountName = "TotalItemCount";
        const string DefaultTotalPageCountName = "TotalPageCount";

        public static INamingScheme Default => new NamingScheme(DefaultPageNumberName, DefaultItemCountPerPageName, DefaultTotalItemCountName, DefaultTotalPageCountName);

        public NamingScheme(string pageNumberName, string itemCountPerPageName, string totalItemCountName, string totalPageCountName, string headerKeyName = DefaultHeaderKeyName)
        {
            PageNumberName = pageNumberName;
            ItemCountPerPageName = itemCountPerPageName;
            TotalItemCountName = totalItemCountName;
            TotalPageCountName = totalPageCountName;
            HeaderKeyName = headerKeyName;
        }

        public string TotalItemCountName { get; private set; }
        public string TotalPageCountName { get; private set; }
        public string PageNumberName { get; private set; }
        public string ItemCountPerPageName { get; private set; }
        public string HeaderKeyName { get; private set; }
    }
}