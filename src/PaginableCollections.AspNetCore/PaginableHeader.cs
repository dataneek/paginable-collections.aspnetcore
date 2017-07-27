namespace PaginableCollections.AspNetCore
{
    public class PaginationHeader
    {
        public PaginationHeader(IPaginable paginable)
        {
            PageNumber = paginable.PageNumber;
            ItemCountPerPage = paginable.ItemCountPerPage;
            TotalItemCount = paginable.TotalItemCount;
            TotalPageCount = paginable.TotalPageCount;
        }

        public int ItemCountPerPage { get; set; }
        public int PageNumber { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
    }
}