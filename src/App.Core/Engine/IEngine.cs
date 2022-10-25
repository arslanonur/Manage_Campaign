using System;
using System.Collections.Generic;
using App.Configuration;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Engine
{
    public interface IEngine
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration, AppConfig appConfig);

        void ConfigureRequestPipeline(IApplicationBuilder application);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);

        void RegisterDependencies(ContainerBuilder containerBuilder, AppConfig appConfig);
    }
}