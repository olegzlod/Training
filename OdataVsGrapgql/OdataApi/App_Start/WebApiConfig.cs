using Microsoft.AspNet.OData.Extensions;
using OdataApi.Entities;
using System.Web.Http;

namespace OdataApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                 defaults: new { controller = "Odata", action = "Get", id = RouteParameter.Optional }
                //defaults: new { id = RouteParameter.Optional }
            );

            var builder = new Microsoft.AspNet.OData.Builder.ODataConventionModelBuilder();
            builder.EntitySet<Student>("Students");

            config.MapODataServiceRoute("OdataRoute", "odata", builder.GetEdmModel(), null);
        }

    }
}
