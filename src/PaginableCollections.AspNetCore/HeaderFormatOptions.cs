namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Blah
    {
        public IMvcBuilder Something(IMvcBuilder b)
        {
            b.UsePaginableHeaders();

            b.UsePaginableHeaders(o => o.UseJson());
            //b.UsePaginableHeaders(o => o.UseJson(s => s.PageNumberNamed("").TotalItemCountNamed("")));
            b.UsePaginableHeaders(o => o.UseJson().WithNamingScheme(s => s.PageNumberNamed("").TotalItemCountNamed("")));


            b.UsePaginableHeaders(o => o.UseText());
            // b.UsePaginableHeaders(o => o.UseText(s => s.PageNumberNamed("").TotalItemCountNamed("")));
            b.UsePaginableHeaders(o => o.UseText().WithNamingScheme(s => s.PageNumberNamed("").TotalItemCountNamed("")));


            b.UsePaginableHeaders(o => o.UseLinks());
            // b.UsePaginableHeaders(o => o.UseJson(s => s.PageNumberNamed("").TotalItemCountNamed("")));
            return b;
        }
    }

    public class HeaderFormatOptions
    {
        public INamingScheme NamingScheme { get; set; }
        public Type FilterType { get; set; }

    
        public IJsonHeaderFormatOptionsBuilder UseJson()
        {
            return new JsonHeaderFormatOptionsBuilder(this);
        }

        public ITextHeaderFormatOptionsBuilder UseText()
        {
            return new TextHeaderFormatOptionsBuilder(this);
        }

        public ILinkHeaderFormatOptionsBuilder UseLinks()
        {
            return new LinkHeaderFormatOptionsBuilder(this);
        }
    }

    public interface IHeaderFormatOptionsBuilder
    {
        HeaderFormatOptions Options { get; set; }
    }

    public interface ITextHeaderFormatOptionsBuilder : IUseNamingSchemeBuilder, IHeaderFormatOptionsBuilder
    {

    }

    public interface IJsonHeaderFormatOptionsBuilder : IUseNamingSchemeBuilder, IHeaderFormatOptionsBuilder
    {

    }

    public interface ILinkHeaderFormatOptionsBuilder : IHeaderFormatOptionsBuilder
    {

    }

    public class TextHeaderFormatOptionsBuilder : ITextHeaderFormatOptionsBuilder
    {
        public TextHeaderFormatOptionsBuilder(HeaderFormatOptions options)
        {
            this.Options = options;
            this.Options.FilterType = typeof(ExpandedHeadersActionFilter);
        }


        public HeaderFormatOptions Options { get; set; }


        IUseNamingSchemeBuilder IUseNamingSchemeBuilder.WithNamingScheme(Action<INamingSchemeBuilder> builder)
        {
            var namingSchemeBuilder = new NamingSchemeBuilder();
     
            builder(namingSchemeBuilder);
            Options.NamingScheme = namingSchemeBuilder.Build();
            return this;
        }
    }

    public class JsonHeaderFormatOptionsBuilder : IJsonHeaderFormatOptionsBuilder
    {
        public JsonHeaderFormatOptionsBuilder(HeaderFormatOptions options)
        {
            this.Options = options;
            this.Options.FilterType = typeof(CondensedHeadersActionFilter);
        }

        public HeaderFormatOptions Options { get; set; }

        IUseNamingSchemeBuilder IUseNamingSchemeBuilder.WithNamingScheme(Action<INamingSchemeBuilder> builder)
        {
            var namingSchemeBuilder = new NamingSchemeBuilder();

            builder(namingSchemeBuilder);
            Options.NamingScheme = namingSchemeBuilder.Build();
            return this;
        }
    }

    public class LinkHeaderFormatOptionsBuilder : ILinkHeaderFormatOptionsBuilder
    {
        public LinkHeaderFormatOptionsBuilder(HeaderFormatOptions options)
        {
            this.Options = options;
            this.Options.FilterType = typeof(LinkHeadersActionFilter);
            this.Options.NamingScheme = null;
        }

        public HeaderFormatOptions Options { get; set; }
    }



    public interface IBuilderContext
    {
        void SetOptions(Action<HeaderFormatOptions> options);
    }


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


    internal static class BuilderContextExtensions
    {
        public static IMvcBuilder AddHeaderFormatOptions(this IMvcBuilder builder, Action<HeaderFormatOptions> options)
        {
            builder.ToBuilderContext().SetOptions(options);
           
            return builder;
        }

        public static IMvcCoreBuilder AddHeaderFormatOptions(this IMvcCoreBuilder builder, Action<HeaderFormatOptions> options)
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