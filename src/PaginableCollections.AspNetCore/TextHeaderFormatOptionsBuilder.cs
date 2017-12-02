namespace PaginableCollections.AspNetCore
{
    using System;
    using PaginableCollections.AspNetCore.Filters;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class TextHeaderFormatOptionsBuilder : ITextHeaderFormatOptionsBuilder
    {
        public TextHeaderFormatOptionsBuilder(HeaderFormatOptions options)
        {
            this.Options = options;
            this.Options.FilterType = typeof(TextHeadersActionFilter);
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
}