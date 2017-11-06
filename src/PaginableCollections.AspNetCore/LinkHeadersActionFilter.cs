namespace PaginableCollections.AspNetCore
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.Routing;

    public class LinkHeadersActionFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is IPaginable paginable)
            {
                var urlHelper = new UrlHelper(context);
                var builder = new List<string>();

                if (paginable.HasPreviousPage)
                {
                    builder.Add(BuildNavigationLink("first", 1, paginable.ItemCountPerPage, urlHelper, context));
                    builder.Add(BuildNavigationLink("prev", paginable.PageNumber - 1, paginable.ItemCountPerPage, urlHelper, context));
                }

                builder.Add(BuildNavigationLink("current", paginable.PageNumber, paginable.ItemCountPerPage, urlHelper, context));

                if (paginable.HasNextPage)
                {
                    builder.Add(BuildNavigationLink("next", paginable.PageNumber + 1, paginable.ItemCountPerPage, urlHelper, context));
                    builder.Add(BuildNavigationLink("last", paginable.TotalPageCount, paginable.ItemCountPerPage, urlHelper, context));
                }

                context.HttpContext.Response.Headers.Add("Link", string.Join(",", builder.ToArray()));
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context) { }

        private string BuildNavigationLink(string rel, int pageNumber, int itemCountPerPage, IUrlHelper urlHelper, ActionExecutedContext context)
        {
            var navigateUrl = urlHelper.RouteUrl(null, new { pageNumber, itemCountPerPage }, context.HttpContext.Request.Scheme);
            var result = $"<{navigateUrl}>; rel=\"{rel}\"";

            return result;
        }
    }
}