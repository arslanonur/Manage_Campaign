using App.Configuration;
using App.Dependency;
using App.Reflection;
using Autofac;

namespace App
{
    public class CoreDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
        }

        public int Order => 1;
    }
}