namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    public class CondensedHeadersActionFilter : IActionFilter
    {
        private const string HeaderPrefix = "X-Paginable";

        private readonly IOptions<MvcJsonOptions> options;

        public CondensedHeadersActionFilter(IOptions<MvcJsonOptions> options)
        {
            this.options = options;
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
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