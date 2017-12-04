namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class UseJsonPaginationResponseHeadersActionFilter : ActionFilterAttribute
    {
        private const string HeaderPrefix = "X-Paginable";

        private readonly INamingScheme namingScheme;
        private readonly IOptions<MvcJsonOptions> options;

        public UseJsonPaginationResponseHeadersActionFilter(INamingScheme namingScheme, IOptions<MvcJsonOptions> options)
        {
            this.namingScheme = namingScheme;
            this.options = options;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is IPaginable paginable)
            {
                context.HttpContext.Response.Headers.Add(
                    HeaderPrefix,
                    JsonConvert.SerializeObject(
                        GetPaginationOutput(paginable), options.Value.SerializerSettings));
            }
        }

        private JObject GetPaginationOutput(IPaginable paginable)
        {
            var result = 
                new JObject(
                    new JProperty(namingScheme.PageNumberName, paginable.PageNumber),
                    new JProperty(namingScheme.ItemCountPerPageName, paginable.ItemCountPerPage),
                    new JProperty(namingScheme.TotalPageCountName, paginable.TotalPageCount),
                    new JProperty(namingScheme.TotalItemCountName, paginable.TotalItemCount));

            return result;
        }
    }
}