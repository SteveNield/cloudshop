using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CloudShop
{
    public class CloudShopApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ILogger>().ImplementedBy<AzureTraceLogger>(),
                Component.For<ITraceWrapper>().ImplementedBy<TraceWrapper>(),
                Classes.FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleTransient()
            );
        }
    }
}
