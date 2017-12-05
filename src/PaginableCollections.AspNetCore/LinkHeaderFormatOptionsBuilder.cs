namespace PaginableCollections.AspNetCore
{   
   public class LinkHeaderFormatOptionsBuilder : ILinkHeaderFormatOptionsBuilder
    {
        public LinkHeaderFormatOptionsBuilder(HeaderFormatOptions options)
        {
            this.Options = options;
            this.Options.FilterType = typeof(UseLinkPaginationHeadersActionFilter);
            this.Options.NamingScheme = null;
        }

        public HeaderFormatOptions Options { get; set; }
    }
}