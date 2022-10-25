using App.Configuration;
using App.Reflection;
using Autofac;

namespace App.Dependency
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig appConfig);

        int Order { get; }
    }
}
