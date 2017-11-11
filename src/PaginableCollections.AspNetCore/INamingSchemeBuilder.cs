namespace PaginableCollections.AspNetCore
{
    public interface INamingSchemeBuilder
    {
        INamingSchemeBuilder PageNumberNamed(string pageNumberName);
        INamingSchemeBuilder ItemCountPerPageNamed(string itemCountPerPageName);
        INamingSchemeBuilder TotalItemCountNamed(string totalItemCountName);
        INamingSchemeBuilder TotalPageCountNamed(string totalPageCountName);

        INamingScheme Build();
    }
}