using System;
using System.Linq;
using System.Net;
using App.Configuration;
using App.Engine;
using App.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static (IEngine, AppConfig) ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var appConfig = services.ConfigureStartupConfig<AppConfig>(configuration.GetSection("App"));

            services.AddHttpContextAccessor();
            services.AddMvcCore();

            var engine = EngineContext.Create();
            engine.ConfigureServices(services, configuration, appConfig);

            return (engine, appConfig);
        }

        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();

            configuration.Bind(config);

            services.AddSingleton(config);

            return config;
        }

        public static void AddAppMvc(this IServiceCollection services)
        {
            var mvcBuilder = services.AddControllers()
                .AddControllersAsServices();

            mvcBuilder.AddFluentValidation(configuration =>
            {
                var assemblies = mvcBuilder.PartManager.ApplicationParts
                    .OfType<AssemblyPart>()
                    .Where(part => part.Name.StartsWith("App", StringComparison.InvariantCultureIgnoreCase))
                    .Select(part => part.Assembly);

                configuration.RegisterValidatorsFromAssemblies(assemblies);

                configuration.ImplicitlyValidateChildProperties = true;
            });
        }

        public static void AddAppDbContext(this IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServerWithLazyLoading(services);
            });
        }
    }
}