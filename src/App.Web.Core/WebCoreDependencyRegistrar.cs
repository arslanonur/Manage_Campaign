using App.Configuration;
using App.Dependency;
using App.Reflection;
using Autofac;

namespace App.Web
{
    public class WebCoreDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
        }

        public int Order => 7;
    }
}
