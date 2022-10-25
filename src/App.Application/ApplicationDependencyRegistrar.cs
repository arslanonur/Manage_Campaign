using App.Configuration;
using App.Dependency;
using App.Product;
using App.Reflection;
using Autofac;

namespace App
{
    public class ApplicationDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
            builder.RegisterType<ProductAppService>()
                .As<IProductAppService>()
                .InstancePerLifetimeScope();
        }

        public int Order => 6;
    }
}
