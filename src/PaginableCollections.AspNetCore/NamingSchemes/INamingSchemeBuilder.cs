namespace PaginableCollections.AspNetCore.NamingSchemes
{
    public interface INamingSchemeBuilder
    {
        INamingSchemeBuilder PageNumberNamed(string pageNumberName);
        INamingSchemeBuilder ItemCountPerPageNamed(string itemCountPerPageName);
        INamingSchemeBuilder TotalItemCountNamed(string totalItemCountName);
        INamingSchemeBuilder TotalPageCountNamed(string totalPageCountName);
        INamingSchemeBuilder HeaderKeyNamed(string headerKeyName);

        INamingScheme Build();
    }
}