using App.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace App.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }

        public static void UseAppExceptionHandler(this IApplicationBuilder application)
        {
            var webHostEnvironment = EngineContext.Current.Resolve<IWebHostEnvironment>();
            if (webHostEnvironment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Home/Error");
            }
        }
        
        public static void UseAppMvc(this IApplicationBuilder application)
        {
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
