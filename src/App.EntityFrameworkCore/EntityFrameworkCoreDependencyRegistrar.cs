using App.Configuration;
using App.Dependency;
using App.Domain.Repositories;
using App.EntityFrameworkCore;
using App.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class EntityFrameworkCoreDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
            builder.Register(context => new AppDbContext(context.Resolve<DbContextOptions<AppDbContext>>()))
                .As<IDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfCoreRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }

        public int Order => 4;
    }
}
