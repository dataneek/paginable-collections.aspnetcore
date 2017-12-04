namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using PaginableCollections.AspNetCore;
    
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