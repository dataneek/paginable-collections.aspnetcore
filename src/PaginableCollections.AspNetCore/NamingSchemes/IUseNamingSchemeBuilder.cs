namespace PaginableCollections.AspNetCore.NamingSchemes
{
    using System;
    
    public interface IUseNamingSchemeBuilder
    {
        IUseNamingSchemeBuilder WithNamingScheme(Action<INamingSchemeBuilder> builder);
    }
}