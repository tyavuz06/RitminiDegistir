using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Takas.API.Authentication;

namespace Takas.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			/* BU 3 CODE COOK ONEMLI EGER BIR CLASS ICERISINDE ICOLLECTION TURUNDE DEGER VARSA (ASLINDA ENTITYFRAMEWORK TE BUNA GEREK YOK SADECE LAZY LOADING ICNIG EREK VAR- FLUENT API DE  YAPACAKSAN ICOLLECTION KULLANMALISIN)*/
			// 

			/*************************************************************************************/
			JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // Burası COK ONEMLI
			// Burada ICollectionlar icerisinde loop a girmesini engelliyoruz yoksa internal server hatasi kaliyor.

			/*****************************************************************************************************/
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
