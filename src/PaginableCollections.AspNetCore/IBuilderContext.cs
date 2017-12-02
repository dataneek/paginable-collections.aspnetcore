namespace PaginableCollections.AspNetCore
{
    using System;
    
    public interface IBuilderContext
    {
        void SetOptions(Action<HeaderFormatOptions> options);
    }
}