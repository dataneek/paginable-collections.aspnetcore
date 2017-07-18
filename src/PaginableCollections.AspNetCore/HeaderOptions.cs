namespace PaginableCollections.AspNetCore
{
    public class HeaderOptions
    {
        public HeaderOptions()
        {
            IsCondensed = true;
        }

        public HeaderOptions UseCondensed()
        {
            IsCondensed = true;
            IsExpanded = !IsCondensed;

            return this;
        }

        public HeaderOptions UseExpanded()
        {
            IsExpanded = true;
            IsCondensed = !IsExpanded;

            return this;
        }

        public bool IsCondensed { get; private set; }
        public bool IsExpanded { get; private set; }
    }
}