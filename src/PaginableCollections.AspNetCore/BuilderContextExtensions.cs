namespace PaginableCollections.AspNetCore
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using PaginableCollections.AspNetCore.Internal;

    internal static class BuilderContextExtensions
    {
        public static IMvcBuilder IncludeHeaderFormatOptions(this IMvcBuilder builder, Action<HeaderFormatOptions> options)
        {
            builder.ToBuilderContext().SetOptions(options);
           
            return builder;
        }

        public static IMvcCoreBuilder IncludeHeaderFormatOptions(this IMvcCoreBuilder builder, Action<HeaderFormatOptions> options)
        {
            builder.ToBuilderContext().SetOptions(options);

            return builder;
        }

        public static IBuilderContext ToBuilderContext(this IMvcBuilder builder)
        {
            return new MvcBuilderContextAdapter(builder);
        }

        public static IBuilderContext ToBuilderContext(this IMvcCoreBuilder builder)
        {
            return new MvcCoreBuilderContextAdapter(builder);
        }
    }
}