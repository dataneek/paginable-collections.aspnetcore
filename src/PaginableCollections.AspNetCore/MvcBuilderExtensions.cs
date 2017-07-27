namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using PaginableCollections.AspNetCore;

    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder UsePaginableHeaders(this IMvcBuilder builder)
        {
            return builder.UsePaginableHeaders(t => t.UseExpanded());
        }

        public static IMvcBuilder UsePaginableHeaders(this IMvcBuilder builder, Action<HeaderFormatOptions> options)
        {
            var o = new HeaderFormatOptions();
            options(o);

            switch (o.HeaderFormat)
            {
                case HeaderFormat.Expanded:
                    return builder.AddMvcOptions(t => t.Filters.Add(typeof(ExpandedHeadersActionFilter)));
                default:
                    return builder.AddMvcOptions(t => t.Filters.Add(typeof(CondensedHeadersActionFilter)));
            } 
        }
    }
}