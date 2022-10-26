using App.Configuration;
using App.Dependency;
using App.Campaign;
using App.Product;
using App.Reflection;
using Autofac;
using App.Basket;

namespace App
{
    public class ApplicationDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
            builder.RegisterType<ProductAppService>()
                .As<IProductAppService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CampaignAppService>()
                .As<ICampaignAppService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BasketAppService>()
                .As<IBasketAppService>()
                .InstancePerLifetimeScope();
        }

        public int Order => 6;
    }
}
