namespace PaginableCollections.AspNetCore
{
    public class HeaderFormatOptions
    {
        public HeaderFormatOptions() { }


        public HeaderFormat HeaderFormat { get; set; } = HeaderFormat.Condensed;


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
    }
}