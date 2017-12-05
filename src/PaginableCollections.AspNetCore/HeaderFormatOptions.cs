namespace PaginableCollections.AspNetCore
{   
    using System;
    using PaginableCollections.AspNetCore.NamingSchemes;

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
}