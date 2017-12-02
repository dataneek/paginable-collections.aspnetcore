namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/values/{pageNumber:int}/{itemCountPerPage:int}")]
    public class ValuesController : Controller
    {
        static int[] numbers = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

        [HttpGet]
        public IPaginable<int> Get(int pageNumber, int itemCountPerPage)
        {
            return numbers.ToPaginable(pageNumber, itemCountPerPage);
        }
    }
}