namespace PaginableCollections.AspNetCore
{
    public class NamingScheme : INamingScheme
    {
        const string DefaultPageNumberName = "PageNumber";
        const string DefaultItemCountPerPageName = "ItemCountPerPage";
        const string DefaultTotalItemCountName = "TotalItemCount";
        const string DefaultTotalPageCountName = "TotalPageCount";

        public static INamingScheme Default => new NamingScheme(DefaultPageNumberName, DefaultItemCountPerPageName, DefaultTotalItemCountName, DefaultTotalPageCountName);

        public NamingScheme(string pageNumberName, string itemCountPerPageName, string totalItemCountName, string totalPageCountName)
        {
            PageNumberName = pageNumberName;
            ItemCountPerPageName = ItemCountPerPageName;
            TotalItemCountName = totalItemCountName;
            TotalPageCountName = TotalPageCountName;
        }

        public string TotalItemCountName { get; private set; }
        public string TotalPageCountName { get; private set; }
        public string PageNumberName { get; private set; }
        public string ItemCountPerPageName { get; private set; }
    }
}