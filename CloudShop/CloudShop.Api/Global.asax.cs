using System.Web.Http;
using Castle.Windsor;

namespace CloudShop.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _container;

        public WebApiApplication()
        {
            _container = WindsorContainerFactory.Create();
        }

        protected void Application_Start()
        {
            var webApiConfig = new WebApiConfig(_container);
            GlobalConfiguration.Configure(c => webApiConfig.Configure(c));
        }

        public override void Dispose()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}
