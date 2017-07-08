namespace PaginableCollections.AspNetCore
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    public class CondensedActionFilter : IAsyncActionFilter
    {
        private const string HeaderPrefix = "X-Paginable";

        private readonly IOptions<MvcJsonOptions> options;

        public CondensedActionFilter(IOptions<MvcJsonOptions> options)
        {
            this.options = options;
        }

        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            var paginable = (context.Result as ObjectResult)?.Value as IPaginable;

            if (paginable != null)
            {
                context.HttpContext.Response.Headers.Add(
                    HeaderPrefix,
                    JsonConvert.SerializeObject(
                        new PaginationHeader(paginable), options.Value.SerializerSettings));
            }
        }
    }
}