using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web.Startup
{
    public class CommonStartup : IAppStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles();
            application.UseRouting();
        }

        public int Order => 100;
    }
}
