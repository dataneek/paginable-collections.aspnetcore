namespace PaginableCollections.AspNetCore.Internal
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class MvcBuilderContextAdapter : IBuilderContext
    {
        private readonly IMvcBuilder builder;

        public MvcBuilderContextAdapter(IMvcBuilder builder)
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