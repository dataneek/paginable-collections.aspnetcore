namespace PaginableCollections.AspNetCore
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.Routing;
    using System.Collections.Generic;

    public class ExpandedHeadersActionFilter : IActionFilter
    {
        private const string HeaderPrefix = "X-Paginable";

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is IPaginable paginable)
            {
                var helper = new UrlHelper(context);
                var url1 = helper.RouteUrl(new { pageNumber = 5, itemCountPerPage = 4 });
                var url2 = helper.RouteUrl(new { pageNumber = 2, itemCountPerPage = 10 });

                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-PageNumber", paginable.PageNumber.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-ItemCountPerPage", paginable.ItemCountPerPage.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-TotalItemCount", paginable.TotalItemCount.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-TotalPageCount", paginable.TotalPageCount.ToString());
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context) { }

        private string GenerateLink(string rel, int pageNumber, int itemCountPerPage, IUrlHelper urlHelper, ActionExecutedContext context)
        {
            var url = urlHelper.RouteUrl(null, new { pageNumber, itemCountPerPage }, context.HttpContext.Request.Scheme);
            var result = $"<{url}>; rel=\"{rel}\"";

            return result;
        }
    }
}