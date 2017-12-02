namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using PaginableCollections.AspNetCore;
    using PaginableCollections.AspNetCore.Mvc;
    
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder UsePaginableHeaders(this IMvcBuilder builder)
        {
            return builder.UsePaginableHeaders(o=> o.UseText()); 
        }

        public static IMvcBuilder UsePaginableHeaders(this IMvcBuilder builder, Action<HeaderFormatOptions> options)
        {
            return builder.IncludeHeaderFormatOptions(options);
        }
    }
}