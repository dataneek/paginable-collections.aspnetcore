namespace PaginableCollections.AspNetCore
{
    public class PaginationHeader
    {
        public PaginationHeader(IPaginable paginable)
        {
            this.PageNumber = paginable.PageNumber;
            this.ItemCountPerPage = paginable.ItemCountPerPage;
            this.TotalItemCount = paginable.TotalItemCount;
            this.TotalPageCount = paginable.TotalPageCount;
        }

        public int ItemCountPerPage { get; set; }
        public int PageNumber { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
    }
}