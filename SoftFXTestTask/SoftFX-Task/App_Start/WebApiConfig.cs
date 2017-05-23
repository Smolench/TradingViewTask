﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace SoftFXTestTask.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            configuration.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}