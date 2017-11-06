namespace PaginableCollections.AspNetCore
{
    using System;

    public class HeaderFormatOptions
    {
        public HeaderFormatOptions() { }


        public HeaderFormat HeaderFormat { get; set; } = HeaderFormat.Condensed;
        public INamingSchemeBuilder NamingSchemeBuilder { get; set; } = new NamingSchemeBuilder();


        public HeaderFormatOptions UseCondensed()
        {
            HeaderFormat = HeaderFormat.Condensed;
            return this;
        }

        public HeaderFormatOptions UseExpanded()
        {
            HeaderFormat = HeaderFormat.Expanded;
            return this;
        }

        public HeaderFormatOptions UseLinkBased()
        {
            HeaderFormat = HeaderFormat.LinkBased;
            return this;
        }

        public void WithNamingScheme(Action<INamingSchemeBuilder> builder)
        {
            builder(this.NamingSchemeBuilder);
        }
    }
}