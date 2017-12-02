namespace PaginableCollections.AspNetCore
{
    using System;
    
    public interface IUseNamingSchemeBuilder
    {
        IUseNamingSchemeBuilder WithNamingScheme(Action<INamingSchemeBuilder> builder);
    }
}