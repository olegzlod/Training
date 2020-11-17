using System.Linq;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdataApiCore.Entities;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;

namespace OdataApiCore
{
   
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);
            services.AddMvc();
            services.AddOData();
            services.AddDbContext<DAL>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var builder = new ODataConventionModelBuilder(app.ApplicationServices);

            builder.EntitySet<Student>("Students");

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();

                routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
                // uncomment the following line to Work-around for #1175 in beta1
                routeBuilder.EnableDependencyInjection();

                // routeBuilder.Select().Filter();
                //routeBuilder.MapODataServiceRoute("OdataRoute", "odata", GetEdmModel());
            });
        }
        //public void Configure(IApplicationBuilder app)
        //{
        //    var builder = new ODataConventionModelBuilder(app.ApplicationServices);

        //    builder.EntitySet<Product>("Products");
        //    builder.EntitySet<Student>("Students");

        //    app.UseMvc(routeBuilder =>
        //    {
        //        // and this line to enable OData query option, for example $filter
        //        routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();

        //        routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());

        //        // uncomment the following line to Work-around for #1175 in beta1
        //        // routeBuilder.EnableDependencyInjection();
        //    });
        //}
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Students");
            return builder.GetEdmModel();
        }

    }
}
