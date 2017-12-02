namespace PaginableCollections.AspNetCore
{
    using PaginableCollections.AspNetCore.Filters;
    
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
}