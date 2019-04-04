using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Takas.API.Authentication;

namespace Takas.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
			config.MessageHandlers.Add(new WebApiKeyHandler()); // Authentication islemi icin burayi ekledim.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
