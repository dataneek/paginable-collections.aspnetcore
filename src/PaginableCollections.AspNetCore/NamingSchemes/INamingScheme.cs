namespace PaginableCollections.AspNetCore.NamingSchemes
{
    public interface INamingScheme
    {
        string HeaderKeyName { get; }
        string TotalItemCountName { get; }
        string TotalPageCountName { get; }
        string PageNumberName { get; }
        string ItemCountPerPageName { get; }
    }
}