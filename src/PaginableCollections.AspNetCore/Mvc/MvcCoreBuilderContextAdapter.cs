namespace PaginableCollections.AspNetCore.Mvc
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class MvcCoreBuilderContextAdapter : IBuilderContext
    {
        private readonly IMvcCoreBuilder builder;

        public MvcCoreBuilderContextAdapter(IMvcCoreBuilder builder)
        {
            this.builder = builder;
        }

        void IBuilderContext.SetOptions(Action<HeaderFormatOptions> options)
        {
            var o = new HeaderFormatOptions();
            options(o);

            builder.AddMvcOptions(t => t.Filters.Add(o.FilterType));

            if (o.NamingScheme != null)
            {
                builder.Services.AddSingleton<INamingScheme>(o.NamingScheme);
            }
        }
    }
}