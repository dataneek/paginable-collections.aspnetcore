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

        public static IMvcBuilder UsePaginableHeaders(this IMvcBuilder builder, Action<HeaderOptions> options)
        {
            var o = new HeaderOptions();
            options(o);

            if (o.IsCondensed)
                return builder.AddMvcOptions(t => t.Filters.Add(typeof(CondensedHeadersActionFilter)));
            else
                return builder.AddMvcOptions(t => t.Filters.Add(typeof(ExpandedHeadersActionFilter)));
        }
    }
}