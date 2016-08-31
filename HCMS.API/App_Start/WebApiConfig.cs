using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;

namespace HCMS.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "ActionApi",
               routeTemplate: "api/{controller}/{action}/{obj}",
               defaults: new { obj = RouteParameter.Optional }
           );

           // config.Routes.MapHttpRoute(
           //    name: "MenuListApi",
           //    routeTemplate: "api/{controller}/{action}/{role}/{level}/{parentID}",
           //    defaults: new { controller="Menu", action = "GetMenuList", role = "Admin", level = 0, parentID = 0}
           //);
            config.Routes.MapHttpRoute("MenuList", "api/{controller}/{action}/{role}/{level}",
                    new
                    {
                        role = UrlParameter.Optional,
                        level = UrlParameter.Optional
                    });

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
