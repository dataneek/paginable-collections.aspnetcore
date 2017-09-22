namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExpandedHeadersActionFilter : IActionFilter
    {
        private const string HeaderPrefix = "X-Paginable";

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is IPaginable paginable)
            {
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-PageNumber", paginable.PageNumber.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-ItemCountPerPage", paginable.ItemCountPerPage.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-TotalItemCount", paginable.TotalItemCount.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-TotalPageCount", paginable.TotalPageCount.ToString());
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context) { }
    }
}