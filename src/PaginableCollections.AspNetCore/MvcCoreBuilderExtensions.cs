namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using PaginableCollections.AspNetCore;

    public static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder UsePaginableHeaders(this IMvcCoreBuilder builder)
        {
            return builder.UsePaginableHeaders(t => t.UseExpanded());
        }

        public static IMvcCoreBuilder UsePaginableHeaders(this IMvcCoreBuilder builder, Action<HeaderFormatOptions> options)
        {
            var o = new HeaderFormatOptions();
            options(o);

            switch (o.HeaderFormat)
            {
                case HeaderFormat.Expanded:
                    return builder.AddMvcOptions(t => t.Filters.Add(typeof(ExpandedHeadersActionFilter)));
                case HeaderFormat.LinkBased:
                    return builder.AddMvcOptions(t => t.Filters.Add(typeof(LinkHeadersActionFilter)));
                default:
                    return builder.AddMvcOptions(t => t.Filters.Add(typeof(CondensedHeadersActionFilter)));
            }
        }
    }
}