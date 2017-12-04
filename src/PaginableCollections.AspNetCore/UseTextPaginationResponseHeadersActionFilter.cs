namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using PaginableCollections.AspNetCore.NamingSchemes;

    public class UseTextPaginationResponseHeadersActionFilter : ActionFilterAttribute
    {
        private const string HeaderPrefix = "X-Paginable";

        private readonly INamingScheme namingScheme;

        public UseTextPaginationResponseHeadersActionFilter(INamingScheme namingScheme)
        {
            this.namingScheme = namingScheme;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is IPaginable paginable)
            {
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-{namingScheme.PageNumberName}", paginable.PageNumber.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-{namingScheme.ItemCountPerPageName}", paginable.ItemCountPerPage.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-{namingScheme.TotalItemCountName}", paginable.TotalItemCount.ToString());
                context.HttpContext.Response.Headers.Add($"{HeaderPrefix}-{namingScheme.TotalPageCountName}", paginable.TotalPageCount.ToString());
            }
        }
    }
}