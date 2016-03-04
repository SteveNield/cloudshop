using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.Windsor;
using Newtonsoft.Json;

namespace CloudShop.Api
{
    public class WebApiConfig
    {
        private readonly IWindsorContainer _windsorContainer;

        public WebApiConfig(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }
        
        public void Configure(HttpConfiguration config)
        {
            ConfigureIoc(config);
            ConfigureRoutes(config);
            ConfigureMediaFormatter(config);
        }

        private void ConfigureIoc(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_windsorContainer));
        }

        private void ConfigureRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "customer", action="get" });
        }

        private static void ConfigureMediaFormatter(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
        }
    }
}