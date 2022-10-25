using App.Configuration;
using App.Engine;
using App.EntityFrameworkCore;
using App.Web.Extensions;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Web
{
    public class WepApiStartup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private IEngine _engine;
        private AppConfig _appConfig;

        public WepApiStartup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAppDbContext();
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();


            (_engine, _appConfig) = services.ConfigureApplicationServices(_configuration);
        }

        public void Configure(IApplicationBuilder application)
        {
            if (_env.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }

            application.ConfigureRequestPipeline();
          
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            _engine.RegisterDependencies(builder, _appConfig);
            
        }
    }
}
