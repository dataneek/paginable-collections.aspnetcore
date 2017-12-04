namespace PaginableCollections.AspNetCore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .UsePaginableHeaders(o =>
                    o.UseText()
                        .WithNamingScheme(s=>
                        {
                            s.PageNumberNamed(Constants.NamingScheme.PageNumberName);
                            s.ItemCountPerPageNamed(Constants.NamingScheme.ItemCountPerPageName);
                            s.TotalItemCountNamed(Constants.NamingScheme.TotalItemCountName);
                            s.TotalPageCountNamed(Constants.NamingScheme.TotalPageCountName);
                        }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}