using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CloudShop.Api
{
    public static class WindsorContainerFactory
    {
        public static IWindsorContainer Create()
        {
            return new WindsorContainer().Install(FromAssembly.This());
        }
    }
}