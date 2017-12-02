namespace PaginableCollections.AspNetCore.NamingSchemes
{
    public interface INamingScheme
    {
        string TotalItemCountName { get; }
        string TotalPageCountName { get; }
        string PageNumberName { get; }
        string ItemCountPerPageName { get; }
    }
}