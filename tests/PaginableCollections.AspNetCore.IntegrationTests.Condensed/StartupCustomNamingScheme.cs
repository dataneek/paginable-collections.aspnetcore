//namespace PaginableCollections.AspNetCore.IntegrationTests.Condensed
//{
//    using Microsoft.AspNetCore.Builder;
//    using Microsoft.AspNetCore.Hosting;
//    using Microsoft.Extensions.Configuration;
//    using Microsoft.Extensions.DependencyInjection;

//    public class StartupCustomNamingScheme
//    {
//        public StartupCustomNamingScheme(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }


//        public IConfiguration Configuration { get; }


//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddMvc()
//                .UsePaginableHeaders(o =>
//                    o.UseCondensed()
//                        .WithNamingScheme(s=>
//                        {
//                            s.PageNumberNamed("page-number");
//                            s.ItemCountPerPageNamed("item-count-per-page");
//                            s.TotalItemCountNamed("total-item-count");
//                            s.TotalPageCountNamed("total-page-count");
//                        }));
//        }

//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            app.UseMvc();
//        }
//    }
//}