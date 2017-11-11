namespace PaginableCollections.AspNetCore
{
    public interface INamingScheme
    {
        string TotalItemCountName { get; }
        string TotalPageCountName { get; }
        string PageNumberName { get; }
        string ItemCountPerPageName { get; }
    }
}