namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using PaginableCollections.AspNetCore;
    using PaginableCollections.AspNetCore.Internal;

    public static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder UsePaginableHeaders(this IMvcCoreBuilder builder)
        {
            return builder.UsePaginableHeaders(t => t.UseText());
        }

        public static IMvcCoreBuilder UsePaginableHeaders(this IMvcCoreBuilder builder, Action<HeaderFormatOptions> options)
        {
            return builder.IncludeHeaderFormatOptions(options);
        }
    }
}