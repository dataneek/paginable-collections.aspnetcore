namespace PaginableCollections.AspNetCore
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ExpandedActionFilter : IAsyncActionFilter
    {
        private const string HeaderPrefix = "X-Paginable";

        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            var paginable = (context.Result as ObjectResult)?.Value as IPaginable;

            if (paginable != null)
            {
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-PageNumber", paginable.PageNumber.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-ItemCountPerPage", paginable.ItemCountPerPage.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-TotalItemCount", paginable.TotalItemCount.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-TotalPageCount", paginable.TotalPageCount.ToString());
            }
        }
    }
}