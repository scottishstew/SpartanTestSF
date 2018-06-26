using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SpartanTestSF
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
                routeTemplate: "api/{controller}/{action}/{value}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
            name: "AllEquipment",
            routeTemplate: "api/{controller}/{action}",
            defaults: new { id = RouteParameter.Optional }
        );
        }
    }
}
