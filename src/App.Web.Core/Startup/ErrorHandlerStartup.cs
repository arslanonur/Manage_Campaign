using App.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web.Startup
{
    public class ErrorHandlerStartup : IAppStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseAppExceptionHandler();
        }

        public int Order => 0;
    }
}
