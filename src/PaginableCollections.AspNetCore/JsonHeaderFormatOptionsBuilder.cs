namespace PaginableCollections.AspNetCore
{
    using System;
    using PaginableCollections.AspNetCore.NamingSchemes;
    
    public class JsonHeaderFormatOptionsBuilder : IJsonHeaderFormatOptionsBuilder
    {
        public JsonHeaderFormatOptionsBuilder(HeaderFormatOptions options)
        {
            this.Options = options;
            this.Options.FilterType = typeof(UseJsonPaginationResponseHeadersActionFilter);
            this.Options.NamingScheme = NamingScheme.Default;
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