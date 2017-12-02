namespace PaginableCollections.AspNetCore.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    public class JsonHeadersActionFilter : IActionFilter
    {
        private const string HeaderPrefix = "X-Paginable";

        private readonly IOptions<MvcJsonOptions> options;

        public JsonHeadersActionFilter(IOptions<MvcJsonOptions> options)
        {
            this.options = options;
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            var url = new UrlHelper(context);

            if ((context.Result as ObjectResult)?.Value is IPaginable paginable)
            {
                context.HttpContext.Response.Headers.Add(
                    HeaderPrefix,
                    JsonConvert.SerializeObject(
                        new PaginationHeader(paginable), options.Value.SerializerSettings));
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context) { }
    }
}