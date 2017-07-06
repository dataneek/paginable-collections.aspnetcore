namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using PaginableCollections.AspNetCore;

    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder UsePaginableHeaders(this IMvcBuilder builder, Action<HeaderOptions> options)
        {
            var o = new HeaderOptions();
            options(o);

            if (o.IsCondensed)
                return builder.AddMvcOptions(t => t.Filters.Add(typeof(CondensedActionFilter)));
            else
                return builder.AddMvcOptions(t => t.Filters.Add(typeof(ExpandedActionFilter)));
        }
    }

    public class HeaderOptions
    {
        public HeaderOptions()
        {
            this.IsCondensed = true;
        }

        public HeaderOptions UseCondensed()
        {
            IsCondensed = true;
            IsExpanded = !IsCondensed;

            return this;
        }

        public HeaderOptions UseExpanded()
        {
            IsExpanded = true;
            IsCondensed = !IsExpanded;

            return this;
        }

        public bool IsCondensed { get; private set; }
        public bool IsExpanded { get; private set; }
    }
}